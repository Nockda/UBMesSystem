package kr.co.micube.mes.com.rule;

import kr.co.micube.tool.message.dataset.support.DatasetRule;

public class SaveFileInfo extends DatasetRule {
	public void doEvent() throws Throwable {

//		IDataSet ds = this.getRequestDataset();
//		IDataTable filetable = ds.getTable("filelist");
//		IDataRow row = null;
//		String state = null;
//		ISQLUpsertBatch batch = new SQLUpsertBatch();
//		IMessage msg = this.getMessage().get();
//		IData jmsg = msg.get();
//		IData body = jmsg.get(MessageFormat.Body);
//		String valid = body.getString("validstate");
//		String srno = body.getString("srno");
//		String version = body.getString("resourceversion");
//		String fileId = "";
//
//		for (int i = 0; i < filetable.size(); i++) {
//			row = filetable.getRow(i);
//			state = row.getString("_STATE_");
//			fileId = Generate.createID("FILE-");
//			switch (state) {
//			case UpsertState.INSERT:
//				batch.add(getFileMapInsertData(row, valid, srno, version, fileId), SQLUpsertType.INSERT);
//				break;
//			case UpsertState.UPDATE:
//				batch.add(getFileMapUpdateData(row, srno, version), SQLUpsertType.UPDATE);
//				break;
//			case UpsertState.DELETE:
//				batch.add(getFileMapDeleteData(row, srno, version), SQLUpsertType.DELETE);
//				break;
//
//			}
//			switch (state) {
//			case UpsertState.INSERT:
//				batch.add(getFileInsertData(row, valid, fileId), SQLUpsertType.INSERT);
//				break;
//			case UpsertState.UPDATE:
//				batch.add(getFileUpdateData(row), SQLUpsertType.UPDATE);
//				break;
//			case UpsertState.DELETE:
//				batch.add(getFileDeleteData(row), SQLUpsertType.DELETE);
//				break;
//
//			}
//
//		}
//		batch.execute();
//
	}
//
//	/************************************************************************************************
//	 * Objectfilemap 등록
//	 * 
//	 * @throws ParseException
//	 */
//	private ObjectfilemapData getFileMapInsertData(IDataRow row, String validstate, String srno, String version,
//			String fileId)
//			throws InValidDataException, DatabaseException, MESException, SystemException, ParseException {
//		ObjectfilemapData ObjectfilemapData = new ObjectfilemapData();
//		ObjectfilemapKey ObjectfilemapKey = ObjectfilemapData.key();
//		ObjectfilemapKey.setResourceid(srno);
//		ObjectfilemapKey.setResourcetype("SR");
//		ObjectfilemapKey.setResourceversion(version);
//		ObjectfilemapKey.setFileid(fileId);
//
//		ObjectfilemapData = ObjectfilemapData.selectOne();
//
//		if (ObjectfilemapData != null) {
//			throw new InValidDataException("InValidData002", String.format("RESOURCEID = %s", srno));
//		}
//
//		ObjectfilemapData = new ObjectfilemapData();
//		ObjectfilemapKey = ObjectfilemapData.key();
//		ObjectfilemapKey.setResourceid(srno);
//		ObjectfilemapKey.setResourcetype("SR");
//		ObjectfilemapKey.setResourceversion(version);
//		ObjectfilemapKey.setFileid(fileId);
//		ObjectfilemapData.setSequence(row.getInteger("SEQUENCE"));
//		ObjectfilemapData.setValidstate(validstate);
//
//		return ObjectfilemapData;
//	}
//
//	/************************************************************************************************
//	 * Objectfilemap 업데이트
//	 * 
//	 * @throws ParseException
//	 */
//	private ObjectfilemapData getFileMapUpdateData(IDataRow row, String srno, String version)
//			throws InValidDataException, DatabaseException, MESException, SystemException, ParseException {
//		ObjectfilemapData ObjectfilemapData = new ObjectfilemapData();
//		ObjectfilemapKey ObjectfilemapKey = ObjectfilemapData.key();
//		ObjectfilemapKey.setResourceid(srno);
//		ObjectfilemapKey.setResourcetype("SR");
//		ObjectfilemapKey.setResourceversion(version);
//		ObjectfilemapKey.setFileid(row.getString("FILEID"));
//
//		ObjectfilemapData = ObjectfilemapData.selectOne();
//
//		if (ObjectfilemapData == null) {
//			throw new InValidDataException("InValidData001", String.format("RESOURCEID = %s", srno));
//		}
//
//		ObjectfilemapData.setSequence(row.getInteger("SEQUENCE"));
//
//		return ObjectfilemapData;
//	}
//
//	/************************************************************************************************
//	 * Objectfilemap 삭제
//	 */
//	private ObjectfilemapData getFileMapDeleteData(IDataRow row, String srno, String version)
//			throws InValidDataException, DatabaseException, MESException, SystemException {
//		ObjectfilemapData ObjectfilemapData = new ObjectfilemapData();
//		ObjectfilemapKey ObjectfilemapKey = ObjectfilemapData.key();
//
//		ObjectfilemapKey.setResourceid(srno);
//		ObjectfilemapKey.setResourcetype("SR");
//		ObjectfilemapKey.setResourceversion(version);
//		ObjectfilemapKey.setFileid(row.getString("FILEID"));
//		ObjectfilemapData = ObjectfilemapData.selectOne();
//
//		if (ObjectfilemapData == null) {
//			throw new InValidDataException("InValidData003", String.format("RESOURCEID = %s", srno));
//		}
//
//		return ObjectfilemapData;
//	}
//
//	/************************************************************************************************
//	 * Objectfile 등록
//	 * 
//	 * @throws ParseException
//	 */
//	private ObjectfileData getFileInsertData(IDataRow row, String validstate, String fileId)
//			throws InValidDataException, DatabaseException, MESException, SystemException, ParseException {
//		ObjectfileData ObjectfileData = new ObjectfileData();
//		ObjectfileKey ObjectfileKey = ObjectfileData.key();
//		ObjectfileKey.setFileid(fileId);
//
//		ObjectfileData = ObjectfileData.selectOne();
//
//		if (ObjectfileData != null) {
//			throw new InValidDataException("InValidData002", String.format("FILEID = %s", fileId));
//		}
//
//		ObjectfileData = new ObjectfileData();
//		ObjectfileKey = ObjectfileData.key();
//		ObjectfileKey.setFileid(fileId);
//		ObjectfileData.setFilename(row.getString("FILENAME"));
//		ObjectfileData.setFilesize(row.getInteger("FILESIZE"));
//		ObjectfileData.setFiletype(row.getString("FILETYPE"));
//		ObjectfileData.setFileext(row.getString("FILEEXT"));
//		ObjectfileData.setFilepath(row.getString("FILEPATH"));
//		ObjectfileData.setValidstate(validstate);
//
//		return ObjectfileData;
//	}
//
//	/************************************************************************************************
//	 * Objectfile 업데이트
//	 * 
//	 * @throws ParseException
//	 */
//	private ObjectfileData getFileUpdateData(IDataRow row)
//			throws InValidDataException, DatabaseException, MESException, SystemException, ParseException {
//
//		ObjectfileData ObjectfileData = new ObjectfileData();
//		ObjectfileKey ObjectfileKey = ObjectfileData.key();
//		ObjectfileKey.setFileid(row.getString("FILEID"));
//
//		ObjectfileData = ObjectfileData.selectOne();
//
//		if (ObjectfileData == null) {
//			throw new InValidDataException("InValidData001", String.format("FILEID = %s", row.getString("FILEID")));
//		}
//
//		ObjectfileKey.setFileid(row.getString("FILEID"));
//		ObjectfileData.setFilename(row.getString("FILENAME"));
//		ObjectfileData.setFilesize(row.getInteger("FILESIZE"));
//		ObjectfileData.setFiletype(row.getString("FILETYPE"));
//		ObjectfileData.setFileext(row.getString("FILEEXT"));
//		ObjectfileData.setFilepath(row.getString("FILEPATH"));
//
//		return ObjectfileData;
//
//	}
//
//	/************************************************************************************************
//	 * Objectfile 삭제
//	 */
//	private ObjectfileData getFileDeleteData(IDataRow row)
//			throws InValidDataException, DatabaseException, MESException, SystemException {
//
//		ObjectfileData ObjectfileData = new ObjectfileData();
//		ObjectfileKey ObjectfileKey = ObjectfileData.key();
//		ObjectfileKey.setFileid(row.getString("FILEID"));
//
//		ObjectfileData = ObjectfileData.selectOne();
//
//		if (ObjectfileData == null) {
//			throw new InValidDataException("InValidData003", String.format("FILEID = %s", row.getString("FILEID")));
//		}
//
//		return ObjectfileData;
//	}

}
