using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WabiLogic.Foundation.Storage.BasicBase
{
    public partial class BasicDataSet
    {
        private static Guid VERSION_1 = new Guid("936E3566-1861-45d0-A4F8-7FF3E62C52A0");

        public static BasicDataSet Create()
        {
            BasicDataSet set = new BasicDataSet();
            //Add root Folder -- Value will always be BasicManager.RootId
            BasicDataSet.FolderRow fr = set.Folder.AddFolderRow(BasicManager.RootId);
            //Add root instance
            set.FolderInstance.AddFolderInstanceRow(Guid.NewGuid(), fr, "Root", fr, DateTime.Now, DateTime.MaxValue);

            return set;
        }

        public static BasicDataSet Load(Stream inputStream)
        {
            BasicDataSet set = null;

            //try {
            //BinaryFormatter bf = new BinaryFormatter();
            //set = bf.Deserialize(inputStream) as BasicDataSet;
            set = new BasicDataSet();

            BinaryReader br = new BinaryReader(inputStream, System.Text.Encoding.UTF8);

            Guid fileVersion = new Guid(br.ReadBytes(16));
            if (fileVersion != VERSION_1)
                throw new UnknownVersionException("File version is unknown.");

            //Load FolderIds
            set.Folder.BeginLoadData();
            long folderCount = br.ReadInt64();
            for (long i = 0; i < folderCount; i++)
            {
                set.Folder.AddFolderRow(new Guid(br.ReadBytes(16)));
            }
            set.Folder.EndLoadData();

            //Load FileIds
            set.File.BeginLoadData();
            long fileCount = br.ReadInt64();
            for (long i = 0; i < fileCount; i++)
            {
                set.File.AddFileRow(new Guid(br.ReadBytes(16)));
            }
            set.File.EndLoadData();

            //Load FolderInstances
            set.FolderInstance.BeginLoadData();
            long folderInstanceCount = br.ReadInt64();
            for (long i = 0; i < folderInstanceCount; i++)
            {
                Guid folderInstanceId = new Guid(br.ReadBytes(16));
                BasicDataSet.FolderRow folderRow = set.Folder.FindByFolderId(new Guid(br.ReadBytes(16)));
                string name = br.ReadString();
                BasicDataSet.FolderRow parentFolderRow = set.Folder.FindByFolderId(new Guid(br.ReadBytes(16)));
                DateTime startDate = new DateTime(br.ReadInt64());
                DateTime endDate = new DateTime(br.ReadInt64());
                set.FolderInstance.AddFolderInstanceRow(folderInstanceId, folderRow, name, parentFolderRow, startDate, endDate);
            }
            set.FolderInstance.EndLoadData();

            //Load FileInstances
            set.FileInstance.BeginLoadData();
            long fileInstanceCount = br.ReadInt64();
            for (long i = 0; i < fileInstanceCount; i++)
            {
                Guid fileInstanceId = new Guid(br.ReadBytes(16));
                BasicDataSet.FileRow fileRow = set.File.FindByFileId(new Guid(br.ReadBytes(16)));
                BasicDataSet.FolderRow folderRow = set.Folder.FindByFolderId(new Guid(br.ReadBytes(16)));
                string name = br.ReadString();
                long size = br.ReadInt64();
                string md5 = br.ReadString();
                string note = br.ReadString();
                Guid streamId = new Guid(br.ReadBytes(16));
                DateTime startDate = new DateTime(br.ReadInt64());
                DateTime endDate = new DateTime(br.ReadInt64());
                set.FileInstance.AddFileInstanceRow(fileInstanceId, fileRow, folderRow, name, size, md5, note, streamId, startDate, endDate);
            }
            set.FileInstance.EndLoadData();
            //}
            //catch {
            //    set = null;
            //}
            return set;
        }

        public static void Save(Stream outputStream, BasicDataSet set)
        {
            BinaryWriter bw = new BinaryWriter(outputStream, System.Text.Encoding.UTF8);

            bw.Write(VERSION_1.ToByteArray());

            //Write FolderIds
            bw.Write((long)set.Folder.Count);
            foreach (FolderRow fr in set.Folder)
            {
                bw.Write(fr.FolderId.ToByteArray());
            }

            //Write FileIds
            bw.Write((long)set.File.Count);
            foreach (FileRow fr in set.File)
            {
                bw.Write(fr.FileId.ToByteArray());
            }

            //Write FolderInstances
            bw.Write((long)set.FolderInstance.Count);
            foreach (FolderInstanceRow fir in set.FolderInstance)
            {
                bw.Write(fir.FolderInstanceId.ToByteArray());
                bw.Write(fir.FolderId.ToByteArray());
                bw.Write(fir.Name);
                bw.Write(fir.ParentFolderId.ToByteArray());
                bw.Write(fir.StartDate.Ticks);
                bw.Write(fir.EndDate.Ticks);
            }

            //Write FileInstances
            bw.Write((long)set.FileInstance.Count);
            foreach (FileInstanceRow fir in set.FileInstance)
            {
                bw.Write(fir.FileInstanceId.ToByteArray());
                bw.Write(fir.FileId.ToByteArray());
                bw.Write(fir.FolderId.ToByteArray());
                bw.Write(fir.Name);
                bw.Write(fir.Size);
                bw.Write(fir.MD5);
                bw.Write(fir.Note);
                bw.Write(fir.StreamId.ToByteArray());
                bw.Write(fir.StartDate.Ticks);
                bw.Write(fir.EndDate.Ticks);
            }

            bw.Flush();
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(outputStream, set);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // BasicDataSet
            // 
            this.RemotingFormat = System.Data.SerializationFormat.Binary;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
