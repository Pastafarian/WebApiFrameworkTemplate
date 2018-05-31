using Application.Entities.Interfaces;

namespace Application.Entities
{
    public class Act : IHaveId, IHaveName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}