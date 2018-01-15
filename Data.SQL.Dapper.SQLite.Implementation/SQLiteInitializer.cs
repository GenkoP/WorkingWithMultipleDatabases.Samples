using System;
using System.Data.SQLite;
using System.IO;
using Data.SQL.Common.Contracts;
using Utility.Contracts;

namespace Data.SQL.SQLite.Implementation
{
    public sealed class SQLiteInitializer : IInitializer
    {
        private readonly IDataCommandExecuter dataCommandExecuter;
        private readonly IConfigurationProvider configurationProvider;

        public SQLiteInitializer(IDataCommandExecuter dataCommandExecuter, IConfigurationProvider configurationProvider)
        {
            this.dataCommandExecuter = dataCommandExecuter ?? throw new ArgumentNullException($"{nameof(dataCommandExecuter)} should not be null");
            this.configurationProvider = configurationProvider ?? throw new ArgumentNullException($"{nameof(configurationProvider)} should not be null");
        }

        public void Initialize()
        {
            string dbFilePath = configurationProvider.GetAppSetting("SQLiteTestMultipleDbFilePath");
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
                const string sql = @"CREATE TABLE [Promotions](
                                        [Id][text] NOT NULL,
                                        [Name] [nvarchar](250) NULL,
                                        [CategoryName] [nvarchar](250) NULL);

                                        CREATE TABLE [Users](
                                            [Id] [text] NOT NULL,
                                            [Username] [nvarchar](250) NULL,
                                            [Password] [nvarchar](250) NULL,
                                            [Email] [nvarchar](250) NULL);";

                dataCommandExecuter.Execute(sql);
            }
        }
    }
}
