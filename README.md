# DynamicSql
 Library to create Dynamic SQL without having to use the clumsy way of writing sequential SQL string in .cs files 

Most of the time we tend to write SQL like

```
var SelectUsers = SELECT Users.* FROM Users;

var SelectUsersWithId = SelectUsers + "WHERE Users.Id = {Id}";
```

Above is a simple example where the Production code might be little more compicated with Joins, subquery etc..

```
var builder = new SqlQueryBuilder();

builder.From<Users>()
        .InnerJoin<Users, Auth>((users, auth) => $"{users.Id} = {auth.Id}")
        .Where<Users, Auth>((users, auth) => $"{users.Id} = {auth.Id}")
          .Select<Users, Auth>((users, auth) => $"{users.Id}, {auth.Password}");
```

This library allows you to write SQL queries like above. In order to use it you have to define the Table objects like Users (Example file in Test project)
