using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToClient.Play
{
    public class UnlockRecipesPacket : BasePacket
    {
        public override int PacketId => 0x37;
        public int Action;   //Varint
        public bool CraftingRecipeBookOpen;
        public bool CraftingRecipeBookFilterActive;
        public bool SmeltingRecipeBookOpen;
        public bool SmeltingRecipeBookFilterActive;
        public int ArraySize1;  //Varint
        public string RecipeIDs;  //Array of Identifier
        public int Arraysize2;    //Optional VarInt
        public string[] RecipeIDs1;
        public string[] RecipeIDs2;
        // Array size 2  Recipe IDs  Number of elements in the following array, only present if mode is 0 (init)

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out Action);
            McBoolean.TryParse(ref array, out CraftingRecipeBookOpen);
            McBoolean.TryParse(ref array, out CraftingRecipeBookFilterActive);
            McBoolean.TryParse(ref array, out SmeltingRecipeBookOpen);
            McBoolean.TryParse(ref array, out SmeltingRecipeBookFilterActive);
            McInt.TryParse(ref array, out ArraySize1);
            McString.TryParse(ref array, out RecipeIDs);
            McInt.TryParse(ref array, out Arraysize2);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[UnlockRecipes{base.ToString()}] Action:{Action} CraftingRecipeBookOpen:{CraftingRecipeBookOpen} CraftingRecipeBookFilterActive:{CraftingRecipeBookFilterActive} SmeltingRecipeBookOpen:{SmeltingRecipeBookOpen} SmeltingRecipeBookFilterActive:{SmeltingRecipeBookFilterActive} ArraySize1:{ArraySize1} RecipeIDs:{RecipeIDs} Arraysize2:{Arraysize2}";
        }
    }
}
