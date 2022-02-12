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
                    context.ProductStates.Add(new ProductState() { Name = "Отсутствует" });//1
                    context.ProductStates.Add(new ProductState() { Name = "В наличии" });//2
                    context.ProductStates.Add(new ProductState() { Name = "Забронирован" });//3
                    context.ProductStates.Add(new ProductState() { Name = "В пути" });//4
                    context.ProductStates.Add(new ProductState() { Name = "Выполнен" });//5
                    context.ProductStates.Add(new ProductState() { Name = "Отменён" });//6
                    context.ProductStates.Add(new ProductState() { Name = "Необходимо уточнить" });//7
                    context.ProductStates.Add(new ProductState() { Name = "На пункте выдачи" });//8
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
