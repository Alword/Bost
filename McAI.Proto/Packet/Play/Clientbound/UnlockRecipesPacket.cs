using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
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
        public int ArraySize2;    //Optional VarInt
        public string[] RecipeIDs1;
        public string[] RecipeIDs2;
        // Array size 2  Recipe IDs  Number of elements in the following array, only present if mode is 0 (init)

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Action);
            McBoolean.TryParse(ref array, out CraftingRecipeBookOpen);
            McBoolean.TryParse(ref array, out CraftingRecipeBookFilterActive);
            McBoolean.TryParse(ref array, out SmeltingRecipeBookOpen);
            McBoolean.TryParse(ref array, out SmeltingRecipeBookFilterActive);
            McVarint.TryParse(ref array, out ArraySize1);
            McStringArray.TryParse(ArraySize1, ref array, out RecipeIDs1);
            if (Action == 0)
            {
                McVarint.TryParse(ref array, out ArraySize2);
                McStringArray.TryParse(ArraySize2, ref array, out RecipeIDs2);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"[UnlockRecipes{base.ToString()}] Action:{Action} CraftingRecipeBookOpen:{CraftingRecipeBookOpen}");
            stringBuilder.AppendLine($" CraftingRecipeBookFilterActive:{CraftingRecipeBookFilterActive} SmeltingRecipeBookOpen:{SmeltingRecipeBookOpen} ");
            stringBuilder.AppendLine($" SmeltingRecipeBookFilterActive:{SmeltingRecipeBookFilterActive} ");

            stringBuilder.AppendLine($"ArraySize1: {ArraySize1}");
            AppendRecipeIDs(stringBuilder, ArraySize1, RecipeIDs1);
            stringBuilder.AppendLine($"ArraySize2: {ArraySize2}");
            AppendRecipeIDs(stringBuilder, ArraySize2, RecipeIDs2);
            return stringBuilder.ToString();
        }

        private void AppendRecipeIDs(StringBuilder stringBuilder, int arraysize, string[] recipeIDs)
        {
            if (recipeIDs == null) return;

            foreach (var recipeID in recipeIDs)
            {
                stringBuilder.Append($"{recipeID} ");
            }
            stringBuilder.Append($"{Environment.NewLine}");
        }
    }
}
