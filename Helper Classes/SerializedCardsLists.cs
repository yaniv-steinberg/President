using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace President.Helper_Classes
{
    [Serializable()]
    public class SerializedCardsLists : ISerializable
    {
        private List<Card> leftCards;
//        private List<Card> rightCards;
//        private List<Card> playerCards;

        public SerializedCardsLists()
        {
        }

        public SerializedCardsLists(SerializationInfo info, StreamingContext ctxt)
        {
            this.leftCards = (List<Card>)info.GetValue("LeftCards", typeof(List<Card>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeftCards", this.leftCards);
        }

        public List<Card> LeftCards
        {
            get { return leftCards; }
            set { leftCards = value; }
        } 
    }
}
