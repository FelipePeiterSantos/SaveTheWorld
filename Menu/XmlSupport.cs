using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class XmlSupport
{
	public static void Serialize<T>(string fileName, T obj)
	{
	    if (File.Exists(fileName))
	    {
	        File.Delete(fileName);
	    }
	    XmlSerializer xs = new XmlSerializer(typeof(T));
	    using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
	    {
	        using (StreamWriter wr = new StreamWriter(fs, Encoding.UTF8))
	        {
	            xs.Serialize(wr, obj);
	        }
	    }

	}
}
