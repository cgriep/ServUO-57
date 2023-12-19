using System;
using Server;
using Server.Items;

namespace Server.Items
	{
		public class AmulettDerWolfsritter : SilverNecklace
	{
        private int orgHue = 0;
        [Constructable]
        public AmulettDerWolfsritter() : base()
        {
            Weight = 0.2;
            Name = "Amulett der Wolfsritter";
            Layer = Layer.Neck;
            Hue = 0;
            this.LootType = LootType.Blessed;
        }
        public override bool IsArtifact { get { return true; } }
        public override void OnDoubleClick(Mobile m)
        {
            if (Parent != m)
            {
                m.SendMessage("Leg es an und schau was passiert.....");
            }
            else
            {
                if (m.BodyValue == 400)
                {
                    m.SendMessage("Du fühlst wie die Macht des Amuletts dich verändert.");
                    m.PlaySound(230);
                    m.BodyValue = 100;
                    orgHue = m.Hue;
                    m.Hue = 78;
                    m.RemoveItem(this);
                    m.EquipItem(this);
                }
                else if (m.BodyValue == 100)
                {
                    m.SendMessage("Du fühlst wie die Macht des Amuletts dich verlässt.");
                    m.PlaySound(73);
                    m.BodyValue = 400;
                    m.Hue = orgHue;
                    m.RemoveItem(this);
                    m.EquipItem(this);
                }
                else
                {
                    m.SendMessage("Das Amulett zeigt keine Wirkung bei dir (" + m.BodyValue.ToString() + ")...");
                }
            }
        }

	public override void OnRemoved( Object o )
	{
		if( o is Mobile )
	{
		((Mobile)o).NameMod = null;
	}
		base.OnRemoved( o );
	}

	public AmulettDerWolfsritter( Serial serial ) : base( serial )
	{

	}

	public override void Serialize( GenericWriter writer )
	{
		base.Serialize( writer );
		writer.Write( (int) 0 ); // version
	}

	public override void Deserialize( GenericReader reader )
	{
		base.Deserialize( reader );
		int version = reader.ReadInt();
	}

	}
	}
