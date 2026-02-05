# Git Comment Convention

## Commit Message Format

Each commit message consists of a **header**, a **body** and a **footer**. The header has a special format that includes a **type**, a **scope** and a **subject**:

```
<type>(<scope>): <subject>
<BLANK LINE>
<body>
<BLANK LINE>
<footer>
```

### Type
Must be one of the following:

- **feat**: A new feature
- **fix**: A bug fix
- **docs**: Documentation only changes
- **style**: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- **refactor**: A code change that neither fixes a bug nor adds a feature
- **perf**: A code change that improves performance
- **test**: Adding missing tests or correcting existing tests
- **build**: Changes that affect the build system or external dependencies
- **ci**: Changes to our CI configuration files and scripts
- **chore**: Other changes that don't modify src or test files

### Scope
The scope should be the name of the affected module or component (e.g., api, web, noti, database, etc.)

### Subject
The subject contains a succinct description of the change:
- Use the imperative, present tense: "change" not "changed" nor "changes"
- Don't capitalize the first letter
- No dot (.) at the end

### Examples

```
feat(api): add user authentication endpoint
fix(web): resolve navigation menu display issue
docs(readme): update installation instructions
refactor(noti): restructure SignalR hub connections
chore(deps): update NuGet packages to latest versions
```

## Branch Naming Convention

- `feature/feature-name` - for new features
- `bugfix/bug-description` - for bug fixes
- `hotfix/critical-fix` - for production hotfixes
- `release/version-number` - for release preparation
