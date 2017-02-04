﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi1
{
    public static class GoogleDrive
    {
        public static DriveService NewService()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

            var keyFilePath = @"D:\Repositories\Website-Univeristy-Infromation-System\GoogleDriveApi\UniversitySystem.p12";    // Downloaded from https://console.developers.google.com
            var serviceAccountEmail = "801416430238-compute@developer.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Web site",
            });


            return service;
        }


        public static File createDirectory(DriveService _service, string _title, string _description, string _parent)
        {

            File NewDirectory = null;

            // Create metaData for a new Directory
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference> { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return NewDirectory;
        }

        public static void PrintParents(DriveService service, String fileId)
        {
            ParentsResource.ListRequest request = service.Parents.List(fileId);

            try
            {
                ParentList parents = request.Execute();

                foreach (ParentReference parent in parents.Items)
                {
                    Console.WriteLine("File Id: " + parent.Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
        //private static string GetMimeType(string fileName)
        //{
        //    string mimeType = "application/unknown";
        //    string ext = System.IO.Path.GetExtension(fileName).ToLower();
        //    Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        //    if (regKey != null && regKey.GetValue("Content Type") != null)
        //        mimeType = regKey.GetValue("Content Type").ToString();
        //    return mimeType;
        //}

        //public static File uploadFile(DriveService _service, string _uploadFile, string _parent)
        //{

        //    if (System.IO.File.Exists(_uploadFile))
        //    {
        //        File body = new File();
        //        body.Title = System.IO.Path.GetFileName(_uploadFile);
        //        body.Description = "File uploaded by Diamto Drive Sample";
        //        body.MimeType = GetMimeType(_uploadFile);
        //        body.Parents = new List() { new ParentReference() { Id = _parent } };

        //        // File's content.
        //        byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
        //        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
        //        try
        //        {
        //            FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
        //            request.Upload();
        //            return request.ResponseBody;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occurred: " + e.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("File does not exist: " + _uploadFile);
        //        return null;
        //    }

        //}

        //public static File updateFile(DriveService _service, string _uploadFile, string _parent, string _fileId)
        //{

        //    if (System.IO.File.Exists(_uploadFile))
        //    {
        //        File body = new File();
        //        body.Title = System.IO.Path.GetFileName(_uploadFile);
        //        body.Description = "File updated by Diamto Drive Sample";
        //        body.MimeType = GetMimeType(_uploadFile);
        //        body.Parents = new List() { new ParentReference() { Id = _parent } };

        //        // File's content.
        //        byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
        //        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
        //        try
        //        {
        //            FilesResource.UpdateMediaUpload request = _service.Files.Update(body, _fileId, stream, GetMimeType(_uploadFile));
        //            request.Upload();
        //            return request.ResponseBody;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occurred: " + e.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("File does not exist: " + _uploadFile);
        //        return null;
        //    }

        //}

        //public static bool deleteFile(DriveService _service, string _fileId)
        //{
        //    bool result;
        //    try
        //    {
        //        FilesResource.DeleteRequest DeleteRequest = _service.Files.Delete(_fileId);
        //        DeleteRequest.Execute();
        //        result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        //public static Boolean downloadFile(DriveService _service, File _fileResource, string _saveTo)
        //{

        //    if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
        //    {
        //        try
        //        {
        //            var x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl);
        //            byte[] arrBytes = x.Result;
        //            System.IO.File.WriteAllBytes(_saveTo, arrBytes);
        //            return true;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occurred: " + e.Message);
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        // The file doesn't have any content stored on Drive.
        //        return false;
        //    }
        //}
    }
}
