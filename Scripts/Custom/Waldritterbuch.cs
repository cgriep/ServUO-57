using System;

namespace Server.Items
{
    public class Waldritterbuch : RedBook
    {

        public static readonly BookContent Content = new BookContent(
           "Das Waldritterbuch", "die Waldhüter",
           new BookPageInfo(
               "Das Buch der Waldritter",
               "",
               "",
               "",
               "",
               "",
               "",
               ""),
           new BookPageInfo(
               "Hier können die Erfahrungen",
               "eines Waldritters erfasst",
               "werden.",
               "",
               "",
               "",
               "",
               ""));
        
        [Constructable]
        public Waldritterbuch()
            : base(false)
        {
        }

        public Waldritterbuch(Serial serial)
            : base(serial)
        {
        }
        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Ein Waldritterbuch");
        }

        public override void OnSingleClick(Mobile from)
        {
            this.LabelTo(from, "Waldritterbuch");
        }
        public override BookContent DefaultContent
        {
            get
            {
                return Content;
            }
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
}
