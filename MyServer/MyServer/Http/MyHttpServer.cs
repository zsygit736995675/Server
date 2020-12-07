using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using MyServer.SQL;

namespace MyServer
{
    public class MyHttpServer : HttpServer
    {
        MySqlMng sql;

        public MyHttpServer(int port): base(port)
        {
            sql = new MySqlMng();

            MySqlDataReader reader = sql.getmysqlread("SELECT * FROM myschema.new_table;");
            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                Console.WriteLine(reader.GetInt32("id") + reader.GetString("new_tablecol"));//"userid"是数据库对应的列名，推荐这种方式
            }
        }

        public override void handleGETRequest(HttpProcessor p)
        {
            Console.WriteLine("request: {0}", p.http_url);
            p.writeSuccess();



          //  p.outputStream.WriteLine("helloworld:"+p.http_url);
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);
        }
    }
}
