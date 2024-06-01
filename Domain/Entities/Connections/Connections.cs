using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Connections
{
    public class ConnectionString
    {
        public static string Server;
        public static string ApiUrl;
        public static string WebUrl;
        public static string HubUrl;
        public static string HubUrl2;
        public static string HubUrl3;
        public static string ServerNewGeo;
        public static string TrackMeUrl;
    }

    public class ConnectionStringLocal : IConnectionString
    {
        public string computerName = Environment.MachineName;

        string serverAlter = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string serverHatzalah = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string server = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string serverNewGeo = @"Data Source=localhost; Initial Catalog=newgeo; Integrated Security=True;";
        string server1848 = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string apiUrl = "https://localhost:44319";
        string webUrl = "https://localhost:44318";
        string hubUrl = "https://localhost:44318/HatzalahHub";
        string trackMeUrl = "https://localhost:44318";

        public string Server()
        {
            if (computerName == "DESKTOP-M1L0DDR")
                return serverAlter;
            else if (computerName == "LAPTOP-MMG3QU4S")
                return serverHatzalah;
            else if (computerName == "DESKTOP-NO43DNM")
                return server1848;
            else
                return server;
        }
        public string ApiUrl() { return apiUrl; }
        public string WebUrl() { return webUrl; }
        public string HubUrl() { return hubUrl; }
        public string HubUrl2() { return string.Empty; }
        public string HubUrl3() { return string.Empty; }
        public string ServerNewGeo() { return serverNewGeo; }
        public string TrackMeUrl() { return trackMeUrl; }
    }

    public class ConnectionStringHost : IConnectionString
    {
        public string computerName = Environment.MachineName;

        string server = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string serverNewGeo = @"Data Source=localhost; Initial Catalog=newgeo; Integrated Security=True;";
        string apiUrl = "https://hatzalahmonseyapi.datavanced.com";
        string webUrl = "https://hatzalahmonsey.datavanced.com";
        string hubUrl = "https://hatzalahmonsey.datavanced.com/HatzalahHub";
        string hubUrl2 = "https://monsey.hatzalah.live/HatzalahHub";
        string hubUrl3 = "https://monsey.hatzoloh.live/HatzalahHub";
        string trackMeUrl = "https://monsey.hatzalah.live";

        public string Server() { return server; }
        public string ApiUrl() { return apiUrl; }
        public string WebUrl() { return webUrl; }
        public string HubUrl() { return hubUrl; }
        public string HubUrl2() { return hubUrl2; }
        public string HubUrl3() { return hubUrl3; }
        public string ServerNewGeo() { return serverNewGeo; }
        public string TrackMeUrl() { return trackMeUrl; }
    }

    public class ConnectionStringBeta : IConnectionString
    {
        public string computerName = Environment.MachineName;

        string server = @"Data Source=DESKTOP-8EA1HHN\SQLEXPRESS; Initial Catalog=HatzalahMonseyDB; Integrated Security=True;";
        string serverNewGeo = @"Data Source=localhost; Initial Catalog=newgeo; Integrated Security=True;";
        string apiUrl = "https://monseybetaapi.hatzalah.live";
        string webUrl = "https://monseybeta.hatzalah.live";
        string hubUrl = "https://monseybeta.hatzalah.live/HatzalahHub";
        string trackMeUrl = "https://monseybeta.hatzalah.live";


        public string Server() { return server; }
        public string ApiUrl() { return apiUrl; }
        public string WebUrl() { return webUrl; }
        public string HubUrl() { return hubUrl; }
        public string HubUrl2() { return string.Empty; }
        public string HubUrl3() { return string.Empty; }
        public string ServerNewGeo() { return serverNewGeo; }
        public string TrackMeUrl() { return trackMeUrl; }
    }

    public interface IConnectionString
    {
        string Server();
        string ApiUrl();
        string WebUrl();
        string HubUrl();
        string HubUrl2();
        string HubUrl3();
        string ServerNewGeo();
        string TrackMeUrl();
    }
}
