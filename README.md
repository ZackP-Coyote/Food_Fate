# Food Fate

## Team Members:
- Zack Powell
- Kenneth De La Cruz
- Brandon Varela

## Overview
Food Fate is a web application designed to assist users in finding dinner recommendations within a specified area. Users can enter their desired location, set parameters such as distance and food preferences to receive three random restaurant suggestions.

## Contributions
- **Kenneth De La Cruz** handled the UI design, creating headers, search boxes, backgrounds, and default user images using Bootstrap. The main page was restructured using Bootstrap in lieu of HTML.

- **Zack Powell** managed the Business Logic, utilizing Yelp's API to integrate restaurant data. This involved implementing functionalities to retrieve business information, search for previously visited restaurants using their IDs, and store these IDs in the database for future reference.

- **Brandon Varela** worked on the Data Access Layer, particularly focusing on the database using Google Cloud services to host a MySql server. He implemented three essential tables: UserInfo (basic user data), UserAuth (password hashing using Argon2), and FavRest (storing favorited restaurant IDs). CRUD functions were developed for each table.

## Database Details
The MySql server hosted on Google Cloud comprises three tables:
1. UserInfo: Basic user information like name and email.
2. UserAuth: Passwords hashed using the Argon2 algorithm.
3. FavRest: Storage for favorited restaurant IDs.

**Note:** Access to the Google Cloud SQL database is restricted by specific IP addresses. As a result, the exported database will be included for testing purposes, but the main page and search functionality continue to work seamlessly without database access when not logged in.
