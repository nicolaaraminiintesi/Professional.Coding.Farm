using Professional.Coding.Farm.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class Colour : ValueObject
    {
        public static Colour Red => new Colour("R");
        public static Colour Yellow => new Colour("Y");
        public static Colour Green => new Colour("G");
        public static IEnumerable<Colour> All => new List<Colour> { Red, Yellow, Green };

        public static Colour GetByCode(string code)
        {
            Colour colour = All.FirstOrDefault(c => c.Code == code);

            if (colour == null)
                throw new InvalidOperationException($"Colour with code {code} not found");

            return colour;
        }

        public Colour() { }

        public Colour(string code) => Code = code;

        public string Code { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
        }
    }
}
