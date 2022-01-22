# TODOAPP

<h3>This solution consists of two applications:</h3>

<ol>
  <li>ReactJS Application (TODOAPP/client-app)</li>
  <li>.NET Core Web API Application (TODOAPP)</li>
</ol>

<h3>The .NET Core application is divided into 4 projects</h3>

<ol>
  <li>API (TODOAPP)</li>
  <li>Application (TODOAPP.Application)</li>
  <li>Domain (TODOAPP.Domain)</li>
  <li>Infrastructure (TODOAPP.Infrastructure)</li>
</ol>

<h3>Running the whole application:</h3>

<ol>
  <li>Install reactjs node_modules by running 'npm install' in the reactjs application (TODOAPP/client-app).</li>
  <li>Install .net core nuget packages by running 'dotnet restore' in the package manager console.</li>
  <li>Update database connection string by changing in RegisterServices.cs (TODOAPP.Infrastructure/RegisterServices).</li>
  <li>Update database by running 'Update-Database' in the package manager console.</li>
  <li>Run the .net core application, and the react app should open in the browser.</li>
</ol>

<h3>Functionality:</h3>

This todo application is meant to create tasks and update them accordingly.
First you should login with a valid account (username: test.user, password: T3stU$3r0!), then you will be redirected to the main page.

<h4>Creating a task:</h4>
<ol>
  <li>Click on the green add button in the bottom right corner</li>
  <li>Fill the form with the required details</li>
  <li>Click on the submit button</li>
</ol>

<h4>Editing a task:</h4>
<ol>
  <li>Click on the pen icon button on the row you want to edit</li>
  <li>Update the form with the required details</li>
  <li>Click on the submit button</li>
</ol>

<h4>Deleting a task:</h4>
<ol>
  <li>Click on the trash icon button on the row you want to delete</li>
  <li>Confirm the operation on the confirmation modal</li>
</ol>

<h4>Logging out:</h4>
<ol>
  <li>Click on lock icon in the top navbar</li>
</ol>

<h3>Security:</h3>
<ol>
  <li>All internal api requests require authorization by a jwt token issued after a successful login</li>
  <li>All passwords in the database are hashed & cannot be reversed</li>
</ol>
