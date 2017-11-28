# Contributing to Gyoza
🥢 🥟 *"itadakimasu!"* 🥟 🥢

Congratulations, you are going to contribute to the **Gyoza** repository. 
First of all, we want to thank you for spending time to improve this project!

## Table Of Contents
[Introduction](#introduction)

[How to contribute](#how-to-contribute)
  * [Bugs](#bugs)
  * [Features](#features)
  * [Pull Requests](#pull-requests)

[Conventions](#conventions)
  * [Code](#code)
  * [Test](#test)
  * [Documentation](#documentation)

[Labels](#labels)

## <a id="introduction"></a>🏁 Introduction
The following guidelines ensure your contributions respect the **Gyoza** project philosophy, design, conventions and rules.

> ⚠️ Please don't create an issue for questions. It easier to directly contact the team on [Slack](https://gyoza-team.slack.com), inside public channels (#public or #questions). We also are few developers in **Gyoza** team, so please be patient to have an answer. Thanks for your understanding 🙏!

## <a id="how-to-contribute"></a>❓ How to contribute

### <a id="bugs"></a>🐛 Bugs
Bug reports are one of the contributions you can do on **Gyoza** project. 

First, ensure your bug isn't listed in [issues](https://github.com/Vtek/Gyoza/issues). It is better to contribute to an existing issue instead of creating a new one. It's really important that you respect a specific format for your bug reports (template is available [here](https://raw.githubusercontent.com/Vtek/Gyoza/develop/contributing/bug.md)). This provides an optimal reading for contributors and ease the implementation of fixes.

If a bug can be cover with an unit test, you are more than welcome to write it! It's one of the best way to quickly resolve the issue 👍

### <a id="features"></a>💡 Features
Features can add some new capabilities to the project. 

First, ensure your feature isn't listed in [issues](https://github.com/Vtek/Gyoza/issues). A feature needs to respect a specific format (template is available [here](https://raw.githubusercontent.com/Vtek/Gyoza/develop/contributing/feature.md)).

A feature must be created as a proposal for discussion with the community. When an agreement is found between community and **Gyoza** team, the proposal is added as a feature inside a [project](https://github.com/Vtek/Gyoza/projects). A feature can be considered too large to be a single card in a project. If so, **Gyoza** team can decide to create the feature as a project and split it into multiples small features (for an easier integration inside the project).

### <a id="pull-requests"></a>🎁 Pull Requests
First, you need to take a look at [Conventions](#conventions) to ensure your code respect **Gyoza** project rules. These rules are mandatories to ensure each pull request respects the philosophy of the **Gyoza** project.

Currently team members use [Gitflow](http://nvie.com/posts/a-successful-git-branching-model/) as branching strategy. In consequence each pull requests must have a linked issue and a feature branch.

#### Clone
If you're an external contributor you need to fork the project first. Team members can directly clone **Gyoza** repository.

Git command example:
```
$ git clone https://github.com/{origin}/Gyoza
```

#### Authorship
All commits must be made with your personnal **Github** account (Take a look at Github documentation to set your user [name](https://help.github.com/articles/setting-your-username-in-git/) & [email](https://help.github.com/articles/setting-your-email-in-git/))

#### Branch
You must create a new branch before committing anything. Feature branches must be created from "*develop*" branch.

> ⚠️ Team members recommand to clearly set the feature branch name. Use the issue title with **camelCase** naming convention or simply used the issue identifier prefix with "*issue*" (example: "*feature/validator*" or "*feature/issue3*").

Git command example:
```
$ git checkout -b feature/{featureNameOrIssueId} develop
```

#### Build & test project
To setup developement dependencies, execute "*restore*" command of **dotnet** core cli:
```
$ dotnet restore
```

Gyoza can be direcly built with the "*build*" command of **dotnet** core cli:
```
$ dotnet build
```

Unit tests are executed with the "*test*" command of **dotnet** core cli:
```
$ dotnet test
```

> ⚠️ Always ensure build and test processes succeeded before commit some code inside the repository

#### Commit
Ensure each commit has an understandable message for request reviewers.

Git command example:
```
$ git commit -am"{message}"
```

#### Rebase
Each pull request must be synchronized with remote repository. Gyoza team recommands to use an interactive rebase to synchronize local and remote repositories.

Git command example:
```
$ git fetch
$ git rebase -i origin/develop
```

External contributors have to synchronize local repository with the forked one (Take a look at the Github documentation [here](https://help.github.com/articles/syncing-a-fork/)).

#### Push
Git command example:
```
$ git push {origin} feature/{featureNameOrIssueId}
```

#### Github PR
Pull requests need to respect a specific format (template is available [here](https://raw.githubusercontent.com/Vtek/Gyoza/develop/contributing/pr.md)).

When approved by reviewers, pull request are merged into the "*develop*" branch.

> ⚠️ To be reviewed, build/test/ci processes must succeeded

## <a id="conventions"></a>🤝 Conventions

### <a id="code"></a>⌨️ Code
Please follow the **.Net Framework Design Guidelines** as much as possible. These conventions can be found [here](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/).

### <a id="test"></a>🔬 Test
- [xUnit](https://xunit.github.io/) and [Fluent Assertions](http://fluentassertions.com/) are used to write tests.
- Organize each test with the **Arrange-Act-Assert** (AAA) pattern.
- Name your test with the **Should-When** pattern.
- Asynchronous method tests must be written with **async/await**.
- Avoid use of mocks as much as possible.

**Example**
```csharp
[Fact]
async Task ShouldReturnAllEntities_WhenGetEntitiesWithoutParameters()
{
    //Arrange
    var expected = Context.Entities.ToList();

    //Act
    var actual = await Finder.GetAsync();

    //Assert
    actual.Should().BeEquivalentTo(expected, option => option.WithStrictOrdering());
}
``` 

### <a id="documentation"></a>📚 Documentation
- Use [XML Documentation Comments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments) for **C#** code.
- Use [Markdown](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet) for Wiki documentation.

## <a id="labels"></a>🏷️ Labels
| Name | Description | Color |
| --- | --- | --- |
| bug | Bug reports | ![#](https://placehold.it/15/e74c3c/000000?text=+) |
| enhancement | Feature to implement | ![#](https://placehold.it/15/3498db/000000?text=+) |
| proposal | Feature proposal | ![#](https://placehold.it/15/1abc9c/000000?text=+) |
| documentation | Documentation enhancement | ![#](https://placehold.it/15/ecf0f1/000000?text=+) |
| alm | Application lifecycle management improvment | ![#](https://placehold.it/15/e67e22/000000?text=+) |
| bad-format | Issue doesn't respect format | ![#](https://placehold.it/15/34495e/000000?text=+) |
| release-pending | Will be released in next version | ![#](https://placehold.it/15/2ecc71/000000?text=+) |
| duplicate | Duplicated issue | ![#](https://placehold.it/15/f1c40f/000000?text=+) |
| wontfix | Team decide to not resolve this issue | ![#](https://placehold.it/15/95a5a6/000000?text=+) |
| under-review | Issue/PR is under review | ![#](https://placehold.it/15/FFFFFF/000000?text=+) |
| information-needed | Issue need more information | ![#](https://placehold.it/15/9b59b6/000000?text=+) |
