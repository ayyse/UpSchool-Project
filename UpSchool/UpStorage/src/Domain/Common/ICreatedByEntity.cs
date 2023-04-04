namespace Domain.Common
{
    public interface ICreatedByEntity
    {
        DateTimeOffset CreatedOn { get; set; }
        string? CreatedByUserId { get; set; } // string diğer veri türlerini(int guid vs.) karşılar
    }
}
