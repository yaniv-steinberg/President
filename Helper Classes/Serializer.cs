﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace President.Helper_Classes
{
    public class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeObject(string filename, SerializedCardsLists objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public SerializedCardsLists DeSerializeObject(string filename)
        {
            SerializedCardsLists objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (SerializedCardsLists)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
