using MilitaryElite.Interface;
using System.Text;

namespace MilitaryElite.Model
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get;
            private set;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Spy:");
            sb.AppendLine(base.ToString().TrimEnd());
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd(); ;
        }
    }
}
