namespace CommonData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CommonData.ContextBD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CommonData.ContextBD context)
        {
            try
            {
                if(context.ProductStates.Count() == 0)
                {
                    context.ProductStates.Add(new ProductState() { Name = "Отсутствует" });
                    context.ProductStates.Add(new ProductState() { Name = "В наличии" });
                    context.ProductStates.Add(new ProductState() { Name = "Забронирован" });
                    context.ProductStates.Add(new ProductState() { Name = "В пути" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
