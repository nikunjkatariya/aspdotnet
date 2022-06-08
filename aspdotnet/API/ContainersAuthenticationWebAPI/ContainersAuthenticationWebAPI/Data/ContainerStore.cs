using ContainersAuthenticationWebAPI.Models;

namespace ContainersAuthenticationWebAPI.Data
{
    public class ContainerStore
    {
        private static Containers[] Containers = new Containers[]
        {
            new Containers{Id=1, ContainerID="CON1001", ContainerType="Gas"},
            new Containers{Id=2, ContainerID="CON1002", ContainerType="Goods"},
            new Containers{Id=3, ContainerID="CON1003", ContainerType="Wooden"},
            new Containers{Id=4, ContainerID="CON1004", ContainerType="Heavy"},
        };

        public static IEnumerable<Containers> GetContainers()
        {
            return Containers;
        }

        public static Containers? GetContainer(int id)
        {
            foreach (var container in Containers)
                if (container.Id == id)
                    return container;
            return null;
        }
    }
}
