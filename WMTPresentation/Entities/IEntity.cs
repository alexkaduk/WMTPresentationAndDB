namespace WMTPresentation.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public static class EntityExtension
    {
        public static long NotPersisted = 0;

        public static bool IsNew(this IEntity entity)
        {
            return entity.Id == NotPersisted;
        }
    }

    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
