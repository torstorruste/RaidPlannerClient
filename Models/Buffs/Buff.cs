namespace RaidPlannerClient.Model.Buff
{
    public interface Buff {
        bool HasBuff(Encounter encounter);

        string GetName();

        string GetImageName();
    }

}