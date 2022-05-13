namespace SmartMES.Settings
{
    public interface ISettingRepository
    {
        SettingConfig Get(string userId);

        void Save(string userId, SettingConfig setting);
    }
}
