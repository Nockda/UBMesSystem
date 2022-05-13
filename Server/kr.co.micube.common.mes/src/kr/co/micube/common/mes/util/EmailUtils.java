package kr.co.micube.common.mes.util;

import java.io.File;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import kr.co.micube.common.util.MultiLanguage;
import kr.co.micube.core.FrameEnvironment;
import kr.co.micube.core.config.ISettings;
import kr.co.micube.core.config.Settings;
import kr.co.micube.core.exception.InvalidDataException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.log.Log;
import kr.co.micube.core.nio.exception.NoDataFoundException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.FileUtils;
import kr.co.micube.core.util.ValueFormatter;
import kr.co.micube.tool.nio.email.IMailProperty;
import kr.co.micube.tool.nio.email.MailRecipientType;
import kr.co.micube.tool.nio.email.MailService;
import kr.co.micube.tool.so.mes.UserData;
import kr.co.micube.tool.so.mes.UserKey;
import kr.co.micube.tool.so.support.ISQLDataList;

public class EmailUtils {
	static ISettings _set = null;
	static Map<String, UserData> _users = null;
	static {
		try {
			_set = Settings.get("mail_mes.common_email");
			_users = new HashMap<>();
			
			UserKey uk = null;
			UserData ud = new UserData();
			ISQLDataList<UserData> udl = ud.selectAll();
			for (int i=0,len=udl.size(); i<len; i++) {
				ud = udl.get(i);
				uk = ud.key();
				_users.put(uk.getUserid(), ud);
			}
		} catch (SystemException e) {
			Log.error(EmailUtils.class, "Email.config.init.fail", e);
		}
	}
	
	public static void send(EmailSendData data, String userId) throws InvalidDataException, DatabaseException
	{
		UserData user = new UserData();
		UserKey userKey = user.key();
		userKey.setUserid(userId);
		
		user = user.selectOne();
		
		if (user == null)
		{
			throw new InvalidDataException("UNREGISTEREDUSERID");
		}
		
		sendEmail(data, user.getEmailaddress(), user.getUsername());
	}
	
	/**
	 * 
	 * @param subject		// E-Mail 제묵
	 * @param recipients	// 받는 사람들
	 * @param contentId		// 메일 내용 파일 ID  참고 ChangePassword
	 * @param files			// 첨부파일 (옵션)
	 * @throws Throwable	
	 */
	public static void send(EmailSendData data)
	{
		sendEmail(data, _set.getString("senderId"), _set.getString("senderName"));
	}
	
	private static void sendEmail(EmailSendData data, String senderEmailAddress, String senderName)
	{
		try {
			IMailProperty props = MailService.newMailProperty();
		
			// SMTP IP
			props.setHost(_set.getString("host"));
			
			// SMTP Port
			props.setPort(_set.getInteger("port"));
			
			// User ID
			props.setUser(_set.getString("user"));
			
			// User Password
			props.setPassword(_set.getString("password"));
			
			// 보낸는 사람
			props.setSender(senderEmailAddress, senderName);
			
			// 제목
			props.setSubject(data.getSubject());
			
			props.setAuth(false);
			
			// 받는 사람
			List<String> recipients = data.getRecipients();
			for (String recipient : recipients)
				props.addRecipient(recipient, MailRecipientType.TO);
			
			// 참조
			//props.addRecipient("Cc@Mail.com", EMailRecipientType.CC);
			
			// 숨은 참조
			//props.addRecipient("Bcc@Mail.com", EMailRecipientType.BCC);
			
			// 파일 첨부
			List<File> files = data.getFiles();
			if (files != null) {
				for (File file : files)
					props.addFile(file);
			}
			
			// 보내는 내용
			File content = new File(FrameEnvironment.getConfigPath() + "/Mail/" + data.getContentId() + ".xml");
			if (!content.isFile())
				throw new NoDataFoundException("No content file. {0}", content.getAbsolutePath());
				
			UserData ud = _users.get(data.getUser());
			String lt = ud.getLanguagetype();
			
			String value = null;
			String fileContent = FileUtils.readFileToString(content, FrameEnvironment.getCharSet());
			Map<String, Object> map = new HashMap<>();
			Map<String, Object> parameters = data.getParameters();
			if (parameters != null) {
				for (Entry<String, Object> entry : parameters.entrySet()) {
					value = MultiLanguage.getDictionary(entry.getKey(), lt);
					map.put(entry.getKey(), value);
				}
			}
			fileContent = ValueFormatter.parser(fileContent, parameters);
			props.addContent(fileContent);
			
			// 보내기
			MailService.send(props);
		} catch (Exception e) {
			Log.error(EmailUtils.class, "E-Mail.send.fail", e);
		}
	}
}