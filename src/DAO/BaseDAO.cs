using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using DTO;
using Dapper;

namespace DAO
{
    public class BaseDAO
    {
        protected string DataSourceFile => Environment.CurrentDirectory + "\\SisCursoDB.sqlite";

        protected SQLiteConnection Connection => new SQLiteConnection("Data Source=" + DataSourceFile + ";foreign keys=true;");

        public BaseDAO()
        {
            if (!File.Exists(DataSourceFile))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"
                    CREATE TABLE Contato
                    (
                        Id          integer primary key autoincrement,
                        Nome        varchar(100) not null,
                        Sobrenome   varchar(100) not null,
                        Email       varchar(100) not null
                    );
                    CREATE TABLE Telefone
                    (
                        Id          integer primary key autoincrement,
                        ContatoId   integer,
                        Numero  varchar(100) not null,
                        FOREIGN KEY (ContatoId) REFERENCES Contato(Id)
                    )"
                );
            }
        }
    }
}