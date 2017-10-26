# GivenWhenThen
## Simple, yet powerful BDD library for C#. 
### Used by test step attribute for methods and scenario static class for definition of test scenario.

### NUnit example:

    // Declaration of test steps
    internal class Fixture
    {
        private IRepository<Account> repository;
        private string id;

        [TearDown]
        public void TearDown()
        {
            repository.Clean();
            repository = null;
            id = null;
        }

        [TestStep("Account repository is created.")]
        public void CreateRepository()
        {
            repository = new XmlAccountRepository();
        }

        [TestStep("New account is created in repository.")]
        public void CreateNewAccount()
        {
            var newAccount = new Account("Test Account");
            repository.Create(newAccount);
            id = newAccount.Id;
        }

        [TestStep("New account is deleted in repository.")]
        public void DeleteNewAccount()
        {
            var account = repository.Get(id);
            repository.Delete(account);
        }

        [TestStep("Account repository contains new account.")]
        public void RepositoryContainsNewAccount()
        {
            var account = repository.Get(id);
            Assert.That(account, Is.Not.Null);
        }

        [TestStep("Account repository does not contain new account.")]
        public void RepositoryDoesNotContainsNewAccount()
        {
            var account = repository.Get(id);
            Assert.That(account, Is.Null);
        }
    }
    
    // Tests that implements Fixture class.
    internal class Tests : Fixture
    {
        [Test]
        public void CreateAccount()
        {
            Scenario
                .Given(CreateRepository)
                .When(CreateNewAccount)
                .Then(RepositoryContainsNewAccount)
                .Execute();
        }

        [Test]
        public void DeleteAccount()
        {
            Scenario
                .Given(CreateRepository)
                .And(CreateNewAccount)
                .When(DeleteNewAccount)
                .Then(RepositoryDoesNotContainsNewAccount)
                .Execute();
        }
    }
    

Command line output:
```
Given: Account repository is created. -> Passed
 When: New account is created in repository. -> Passed
 Then: Account repository contains new account. -> Passed
```
