using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace APL.BL.SFTS.ShelterZone
{
    public class ConversionXML
    {
        private static string MasterObjectToXML<TObject>(TObject obj) where TObject : class
        {
            try
            {                
                string spaceString = " ";
                string sAng = "<";      // sAng is Start Angle Bracket
                string eAng = ">";      // eAng is End Angle Bracket               
                string bSlash = "/";    // bSlash is Back Slash

                string objXML = string.Empty;
                string ObjOfClassName = typeof(TObject).Name;

                foreach (var property in typeof(TObject).GetProperties())
                {                    
                    object proValue = property.GetValue(obj, null);
                    string propertyTypeName = property.PropertyType.Name;
                    if (proValue == null)
                    {
                        if (property.PropertyType.FullName.Split('.')[0].Equals("System"))
                        {
                            objXML += spaceString + sAng + property.Name + eAng + (object)DBNull.Value + sAng + bSlash + property.Name + eAng;
                        }
                        continue;
                    }
                    if (property.GetGetMethod().ReturnType.Name.Equals("Nullable`1"))
                    {
                        int startIndex = property.PropertyType.FullName.IndexOf("[[System.") + "[[System.".Length;
                        int endIndex = property.PropertyType.FullName.IndexOf(", mscorlib");
                        propertyTypeName = property.PropertyType.FullName.Substring(startIndex, endIndex - startIndex);
                    }

                    switch (propertyTypeName)
                    {
                        case "byte":
                        case "Byte":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToByte(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "sbyte":
                        case "SByte":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToByte(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "int":
                        case "Int32":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt32(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "uint":
                        case "UInt32":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt32(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "short":
                        case "Int16":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt16(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "ushort":
                        case "UInt16":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt16(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "long":
                        case "Int64":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt64(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "ulong":
                        case "UInt64":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt64(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "float":
                        case "Single":
                        case "double":
                        case "Double":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToDouble(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "char":
                        case "Char":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToChar(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "bool":
                        case "Boolean":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToBoolean(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "object":
                        case "Object":
                            objXML += spaceString + sAng + property.Name + eAng + proValue.ToString() + sAng + bSlash + property.Name + eAng;
                            break;

                        case "string":
                        case "String":
                            objXML += spaceString + sAng + property.Name + eAng + proValue.ToString() + sAng + bSlash + property.Name + eAng;
                            break;

                        case "decimal":
                        case "Decimal":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToDecimal(proValue) + sAng + bSlash + property.Name + eAng;
                            break;

                        case "Date":
                        case "DateTime":
                            objXML += spaceString + sAng + property.Name + eAng + Convert.ToDateTime(proValue).ToString("yyyy-MM-ddThh:mm:ss") + sAng + bSlash + property.Name + eAng;
                            break;
                        default:
                            break;
                    }
                }
                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static string DetailObjectToXML<TObject>(List<TObject> objColl, string collectionNodeLastPart) where TObject : class
        {
            try
            {
                string spaceString = " ";
                string sAng = "<";          // sAng is Start Angle Bracket
                string eAng = ">";          // eAng is End Angle Bracket
                string bSlash = "/";        // bSlash is Back Slash               
                string objCollName = string.Empty;               
                string objXML = string.Empty;

                foreach (object obj in objColl)
                {
                    string ObjOfClassName = typeof(TObject).Name;
                    objCollName = typeof(TObject).Name;

                    objXML += sAng + ObjOfClassName + eAng;
                    foreach (var property in typeof(TObject).GetProperties())
                    {                       
                        object proValue = property.GetValue(obj, null);
                        string propertyTypeName = property.PropertyType.Name;
                        if (proValue == null)
                        {
                            if (property.PropertyType.Namespace.Equals("System"))
                            {
                                objXML += spaceString + sAng + property.Name + eAng + (object)DBNull.Value + sAng + bSlash + property.Name + eAng;
                            }
                            continue;
                        }
                        if (property.GetGetMethod().ReturnType.Name.Equals("Nullable`1"))
                        {
                            int startIndex = property.PropertyType.FullName.IndexOf("[[System.") + "[[System.".Length;
                            int endIndex = property.PropertyType.FullName.IndexOf(", mscorlib");
                            propertyTypeName = property.PropertyType.FullName.Substring(startIndex, endIndex - startIndex);
                        }

                        switch (propertyTypeName)
                        {
                            case "Byte[]":

                                Byte[] by = (byte[])proValue;
                                foreach(int b in by)
                                {
                                    objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt32(b) + sAng + bSlash + property.Name + eAng;
                                }                             
                                break;

                            case "byte":
                            case "Byte":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToByte(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "sbyte":
                            case "SByte":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToByte(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "int":
                            case "Int32":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt32(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "uint":
                            case "UInt32":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt32(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "short":
                            case "Int16":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt16(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "ushort":
                            case "UInt16":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt16(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "long":
                            case "Int64":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToInt64(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "ulong":
                            case "UInt64":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToUInt64(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "float":
                            case "Single":
                            case "double":
                            case "Double":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToDouble(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "char":
                            case "Char":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToChar(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "bool":
                            case "Boolean":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToBoolean(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "object":
                            case "Object":
                                objXML += spaceString + sAng + property.Name + eAng + proValue.ToString() + sAng + bSlash + property.Name + eAng;
                                break;

                            case "string":
                            case "String":
                                objXML += spaceString + sAng + property.Name + eAng + proValue.ToString() + sAng + bSlash + property.Name + eAng;
                                break;

                            case "decimal":
                            case "Decimal":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToDecimal(proValue) + sAng + bSlash + property.Name + eAng;
                                break;

                            case "Date":
                            case "DateTime":
                                objXML += spaceString + sAng + property.Name + eAng + Convert.ToDateTime(proValue).ToString("yyyy-MM-ddThh:mm:ss") + sAng + bSlash + property.Name + eAng;
                                break;
                            default:
                                break;
                        }
                    }
                    objXML += sAng + bSlash + ObjOfClassName + eAng;
                }

                if (collectionNodeLastPart != string.Empty)
                {
                    objCollName = objCollName + collectionNodeLastPart;
                }
                else
                {
                    objCollName = objCollName + "Coll";
                }
                objXML = sAng + objCollName + eAng + objXML + sAng + bSlash + objCollName + eAng;
                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string ConvertObjectToXML<TObject>(TObject obj) where TObject : class
        {
            try
            {
                string sAng = "<";      // sAng is Start Angle Bracket
                string eAng = ">";      // eAng is End Angle Bracket              
                string bSlash = "/";    // bSlash is Back Slash

                string objXML = string.Empty;
                string ObjOfClassName = typeof(TObject).Name;

                objXML += sAng + ObjOfClassName + eAng;
                objXML += MasterObjectToXML<TObject>(obj);
                objXML += sAng + bSlash + ObjOfClassName + eAng;

                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string ConvertObjectToXML<TObject>(List<TObject> objColl, string collectionNodeLastPart) where TObject : class
        {
            try
            {                
                string objXML = string.Empty;
                objXML = DetailObjectToXML<TObject>(objColl, collectionNodeLastPart);
                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string ConvertObjectToXML<TObjectMaster, TObjectDetail>(TObjectMaster objMaster, List<TObjectDetail> objDetailColl, string collectionNodeLastPart)
            where TObjectMaster : class
            where TObjectDetail : class
        {
            try
            {
                string sAng = "<";      // sAng is Start Angle Bracket
                string eAng = ">";      // eAng is End Angle Bracket
                string bSlash = "/";    // bSlash is Back Slash
                string objXML = string.Empty;

                string ObjOfClassName = typeof(TObjectMaster).Name;

                objXML += sAng + ObjOfClassName + eAng;
                objXML += MasterObjectToXML<TObjectMaster>(objMaster);
                objXML += DetailObjectToXML<TObjectDetail>(objDetailColl, collectionNodeLastPart);
                objXML += sAng + bSlash + ObjOfClassName + eAng;

                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string ConvertObjectToXML<TObjectMaster, TObjectFirstDetail, TObjectSecondDetail>(TObjectMaster objMaster, List<TObjectFirstDetail> objFirstDetailColl, List<TObjectSecondDetail> objSecondDetailColl, string collectionNodeLastPart)
            where TObjectMaster : class
            where TObjectFirstDetail : class
            where TObjectSecondDetail : class
        {
            try
            {
                string sAng = "<";      // sAng is Start Angle Bracket
                string eAng = ">";      // eAng is End Angle Bracket
                string bSlash = "/";    // bSlash is Back Slash
                string objXML = string.Empty;

                string ObjOfClassName = typeof(TObjectMaster).Name;

                objXML += sAng + ObjOfClassName + eAng;
                objXML += MasterObjectToXML<TObjectMaster>(objMaster);
                objXML += DetailObjectToXML<TObjectFirstDetail>(objFirstDetailColl, collectionNodeLastPart);
                objXML += DetailObjectToXML<TObjectSecondDetail>(objSecondDetailColl, collectionNodeLastPart);
                objXML += sAng + bSlash + ObjOfClassName + eAng;

                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string ConvertObjectToXML<TObjectMaster, TObjectSingle, TObjectFirstDetail, TObjectSecondDetail>(TObjectMaster objMaster, TObjectSingle objectSingle, List<TObjectFirstDetail> objFirstDetailColl, List<TObjectSecondDetail> objSecondDetailColl, string collectionNodeLastPart)
            where TObjectMaster : class
            where TObjectSingle : class
            where TObjectFirstDetail : class
            where TObjectSecondDetail : class
        {
            try
            {
                string sAng = "<";      // sAng is Start Angle Bracket
                string eAng = ">";      // eAng is End Angle Bracket
                string bSlash = "/";    // bSlash is Back Slash
                string objXML = string.Empty;

                string ObjOfClassName = typeof(TObjectMaster).Name;

                objXML += sAng + ObjOfClassName + eAng;                
                objXML += MasterObjectToXML<TObjectMaster>(objMaster);
                objXML += ConvertObjectToXML<TObjectSingle>(objectSingle);
                objXML += DetailObjectToXML<TObjectFirstDetail>(objFirstDetailColl, collectionNodeLastPart);
                objXML += DetailObjectToXML<TObjectSecondDetail>(objSecondDetailColl, collectionNodeLastPart);
                objXML += sAng + bSlash + ObjOfClassName + eAng;

                return objXML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
