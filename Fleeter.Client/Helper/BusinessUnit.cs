namespace Fleeter.Client.FleeterServiceProxy
{
    public partial class BusinessUnit
    {
        public override bool Equals(object obj)
        {
            return obj is BusinessUnit b && Id == b.Id;
        }
    }
}
