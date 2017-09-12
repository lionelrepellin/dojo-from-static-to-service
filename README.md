# Coding Dojo : From static to service

### Transform old school static classes into sevices and learn how to test it with mock.

To learn how to do it, checkout each commit one by one :
- Basic project with static ADO .Net repository -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/164382a031bc0c7feb0d21bece83758b3d20bbdc)
    - A piece of static code, using ADO .Net : old school, but it works.

- Add a test with static repository -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/45b539427f025b24901a50cdd9ede54fa47d90eb)
    - Add an integration / non-regression test with Nunit & NFluent

- Step 1 : transform static to service -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/47cc8ca6ae28c1825eed36a8a7ac45c77ad0d778)
    - Creates an interface for the repository
    - Remove static keyword from the repo
    - Repository is now passed by constructor to the service
    - Tests are updated

- Step 2 : create a mock of the repository -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/0692699b5720cc4c04a5c4780224f6e27bde7444)
    - Use Moq to create the mock of the repo : the database will not be longer used for tests !

- [Optional] Replace ADO .Net by Entity Framework -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/f64b471576eb5c0f6df144fda61d1d25c25afdde)
    - The repository is simplified with the use of Entity Framework

- [Optional] Add repository pattern and unit of work -> [Clone the repo](https://github.com/lionelrepellin/dojo-from-static-to-service/tree/526bd2c45f49bea3ce5a66df6d4025faba180063)
    - Creates a generic repository and a Unit of Work [based on the Microsoft tutorial](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
    - Tests are updated
    - Unit of work, repositories and service are ready to be used with dependency injection
