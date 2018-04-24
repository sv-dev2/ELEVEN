using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ELEVEN.Settings
{
    #region Types

    /// <summary>
    /// 
    /// </summary>
    public class ElevenSettings
    {
        #region Properties

        #region Public Properties

        [XmlArrayItem("Exchange")]
        public List<Exchange> Exchanges
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the folder settings.
        /// </summary>
        /// <value>
        /// The folder settings.
        /// </value>
        public FolderSettings FolderSettings
        {
            get; set;
        }

        [XmlArrayItem("Security")]
        public List<Security> Securities
        {
            get;
            set;
        }

        #endregion Public Properties

        /// <summary>
        /// Gets or sets the name of the environment file.
        /// </summary>
        /// <value>
        /// The name of the environment file.
        /// </value>
        private static string EnvironmentFileName
        {
            get;
            set;
        }

        #endregion Properties

        public static ElevenSettings Load(string fileNameParam)
        {
            EnvironmentFileName = fileNameParam;
            //var info = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + fileName);
            var info = new FileInfo(EnvironmentFileName);
            if (info.Exists)
            {
                var serializer = new XmlSerializer(typeof(ElevenSettings));
                using (var stream = info.OpenRead())
                {
                    try
                    {
                        return (ElevenSettings)serializer.Deserialize(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.GetBaseException());
                    }
                }
            }
            return new ElevenSettings();
        }

        #region Public Methods

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            try
            {
                //var info = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + fileName);
                var info = new FileInfo(EnvironmentFileName);
                if (info.Exists)
                    info.Delete();

                var serializer = new XmlSerializer(typeof(ElevenSettings));
                using (var stream = info.Create())
                {
                    serializer.Serialize(stream, this);
                }
            }
            catch
            { }
        }

        #endregion Public Methods
    }

    #endregion Types
}
