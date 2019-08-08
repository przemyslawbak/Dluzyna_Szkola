# Dluzyna_Szkola

## Purpose

Commercial web application created from scrap for primary school, where moderators and administrators can CRUD articles, edit plugin entries. Some plugins are connected with database. My first CRUD project.

## Features

1. Two identity roles, for moderator, that can do basic CRUD operations on articles and change color design, and admin, who can additionally manage registered users and their permits.
2. Pagination of the articles.
3. Calendar plugin from layout view is displaying events saved in the database via events tab, where moderators can save new entities.
4. Possible to uplad a picture to the article or to use default one.
5. Recent articles can be accessed via layout plugin called "latest articles".
6. Login panel for users added by administration.
7. Website secured from CSRF, brute-force, XSS and Traversal Path attacks.
8. Administration is able to change website color settings, or switch to mourn color scheme.
9. News plugin displayed in layout view is disapearing after event occurs, can be modified by registered user.
10. Available uploading a file, which will be available for downloading under the article.
11. Complex text edition eveilable for each entry.
12. Layout sidebar that contains several plugins and view components, some of them are editable from registered user level.
13. Editable footer.
14. Weather plugin is temporarily not available.
15. Popup cookies info.

## Technology

1. Approaches:
  - MVC,
  - in several functionalities view components were used,
  - two-levels identity authentication for the site administration,
  - CRUD methods for various types available from admin level,
  - usage of ViewComponent in layout view,
  - screen size responsivity with Bootstrap,
  - color converter from HEX to HSV,
  - global ViewBag action filter for color schemes,
  - several tag helpers (for pagination, roles, color schemes),
  - wysiwyg plugin for entity edits,
  - Glyphicons are used for displaying of some symbols,
  - date and time picker plugin used in edit views,
  - Yahoo! Weather used for weather plugin,
  - color picker plugin in use,
  - simple slideshow plugin for header.
  
2. Application is using:
  - ASP.NET Core,
  - ASP.NET Core Identity,
  - Entity Framework Core,
  - JavaScript,
  - jQuery,
  - Bootstrap,
  - AntiXSS.

## Production

27 Nov 2018
