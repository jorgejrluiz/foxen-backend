using AutoMapper;

namespace TCC.Backend.Tests.Fixtures
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
            });

            Mapper = config.CreateMapper();
        }
    }
}
