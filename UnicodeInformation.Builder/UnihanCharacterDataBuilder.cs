﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Unicode.Builder
{
	internal sealed class UnihanCharacterDataBuilder
	{
		private readonly int codePoint;
		private UnihanNumericType numericType;
		private long numericValue;
		private string definition;
		private string mandarinReading;
		private string cantoneseReading;
		private string japaneseKunReading;
		private string japaneseOnReading;
		private string koreanReading;
		private string hangulReading;
		private string vietnameseReading;
		private string simplifiedVariant;
		private string traditionalVariant;

		public int CodePoint { get { return codePoint; } }
		public UnihanNumericType NumericType { get { return numericType; } set { numericType = value; } }
		public long NumericValue { get { return numericValue; } set { numericValue = value; } }
		public string Definition { get { return definition; } set { definition = value; } }
		public string MandarinReading { get { return mandarinReading; } set { mandarinReading = value; } }
		public string CantoneseReading { get { return cantoneseReading; } set { cantoneseReading = value; } }
		public string JapaneseKunReading { get { return japaneseKunReading; } set { japaneseKunReading = value; } }
		public string JapaneseOnReading { get { return japaneseOnReading; } set { japaneseOnReading = value; } }
		public string KoreanReading { get { return koreanReading; } set { koreanReading = value; } }
		public string HangulReading { get { return hangulReading; } set { hangulReading = value; } }
		public string VietnameseReading { get { return vietnameseReading; } set { vietnameseReading = value; } }
		public string SimplifiedVariant { get { return simplifiedVariant; } set { simplifiedVariant = value; } }
		public string TraditionalVariant { get { return traditionalVariant; } set { traditionalVariant = value; } }

		internal UnihanCharacterDataBuilder(int codePoint)
		{
			this.codePoint = codePoint;
		}

		internal UnihanCharacterData ToCharacterData()
		{
			return new UnihanCharacterData
			(
				codePoint,
				numericType,
				numericValue,
				definition,
				mandarinReading,
				cantoneseReading,
				japaneseKunReading,
				japaneseOnReading,
				koreanReading,
				hangulReading,
				vietnameseReading,
				simplifiedVariant,
				traditionalVariant
			);
		}

		internal void WriteToFile(BinaryWriter writer)
		{
			UnihanFields fields = default(UnihanFields);

			fields |= (UnihanFields)NumericType;
			if (Definition != null) fields |= UnihanFields.Definition;
			if (MandarinReading != null) fields |= UnihanFields.MandarinReading;
			if (CantoneseReading != null) fields |= UnihanFields.CantoneseReading;
			if (JapaneseKunReading != null) fields |= UnihanFields.JapaneseKunReading;
			if (JapaneseOnReading != null) fields |= UnihanFields.JapaneseOnReading;
			if (KoreanReading != null) fields |= UnihanFields.KoreanReading;
			if (HangulReading != null) fields |= UnihanFields.HangulReading;
			if (VietnameseReading != null) fields |= UnihanFields.VietnameseReading;
			if (SimplifiedVariant != null) fields |= UnihanFields.SimplifiedVariant;
			if (TraditionalVariant != null) fields |= UnihanFields.TraditionalVariant;

			writer.Write((ushort)fields);

			writer.WriteCodePoint(UnihanCharacterData.PackCodePoint(codePoint));
			if ((fields & UnihanFields.OtherNumeric) != 0) writer.Write(numericValue);
			if ((fields & UnihanFields.Definition) != 0) writer.Write(Definition);
			if ((fields & UnihanFields.MandarinReading) != 0) writer.Write(MandarinReading);
			if ((fields & UnihanFields.CantoneseReading) != 0) writer.Write(CantoneseReading);
			if ((fields & UnihanFields.JapaneseKunReading) != 0) writer.Write(JapaneseKunReading);
			if ((fields & UnihanFields.JapaneseOnReading) != 0) writer.Write(JapaneseOnReading);
			if ((fields & UnihanFields.KoreanReading) != 0) writer.Write(KoreanReading);
			if ((fields & UnihanFields.HangulReading) != 0) writer.Write(HangulReading);
			if ((fields & UnihanFields.VietnameseReading) != 0) writer.Write(VietnameseReading);
			if ((fields & UnihanFields.SimplifiedVariant) != 0) writer.Write(SimplifiedVariant);
			if ((fields & UnihanFields.TraditionalVariant) != 0) writer.Write(TraditionalVariant);
		}
	}
}
