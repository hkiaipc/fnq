using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class SoapSerialize
    {
        #region SoapSerialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public SoapSerialize(string fileName)
        {
            this.FileName = fileName;
        }
        #endregion //SoapSerialize

        #region FileName
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        } private string _filename;
        #endregion //FileName

        #region Serialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Serialize(object obj)
        {
            try
            {
                SoapFormatter aSoap = new SoapFormatter();
                FileStream fs = new FileStream(_filename, FileMode.Create);

                aSoap.Serialize(fs, obj);
                fs.Close();
            }
            catch
            {
                throw;
            }
        }
        #endregion //Serialize

        #region Deserialize
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Deserialize()
        {
            SoapFormatter aSoap = new SoapFormatter();
            FileStream fs = null;
            object obj = null;
            try
            {
                fs = new FileStream(_filename, FileMode.Open);
                obj = aSoap.Deserialize(fs, null);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (SerializationException)
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            return obj;
        }
        #endregion //Deserialize
    }
}
