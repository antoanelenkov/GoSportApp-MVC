# Go Sport Web Application

* Areas
   - Administation
    
### Administration Controllers
 *  [AdminController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Areas/Administration/Controllers/AdminController.cs)
 *  [AddressController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Areas/Administration/Controllers/AddressesController.cs)
    - Index
    - Create
    - Edit(Get)
    - Edit(Post)
    - Delete
 *  [CategoriesController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Areas/Administration/Controllers/CategoriesController.cs)
    - Index
    - Create
    - Edit(Get)
    - Edit(Post)
    - Delete
 * [SportCentersController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Areas/Administration/Controllers/SportCentersController.cs)
    - Index
    - Edit(Get)
    - Edit(Post)
    - Delete
 
 ### Main Controllers
 * [BaseController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/BaseController.cs)
 * [HomeController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/HomeController.cs)
   - Index
   - About
   - Contact
 * [AccountController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/AccountController.cs)
    - Login
    - Register
 * [AddressController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/AddressController.cs)
    - GetAllNeighbourhoods(Get)
    - GetAllNeighbourhoods(Post)
 * [RatingController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/RatingController.cs)
    - RateSportCenters
 * [SportCenterController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/SportCenterController.cs)
    - Add(Get)
    - Add(Post)
    - Details
    - AddComment
 * [AdvancedController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/AdvancedController.cs)
    - BySortPreferance(Get)
    - BySortPreferance(Post)
    - ByPreferance
 * [UserController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/UserController.cs)
    - Profile
 * [ErrorController](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Controllers/ErrorController.cs)
    - NotFound

## Partial Views
* [AddCommentPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_AddCommentPartial.cshtml)
* [AddressPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_AddressPartial.cshtml)
* [AllCommentsPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_AllCommentsPartial.cshtml)
* [RatingPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_RatingPartial.cshtml)
* [SportCategoriesPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_SportCategoriesPartial.cshtml)
* [SportCenterInfoPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_SportCenterInfoPartial.cshtml)
* [LoginPartial](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Views/Shared/_LoginPartial.cshtml)

## Filters
* [ValidPhoneNumberAttribute](https://github.com/antoanelenkov/GoSportApp-MVC/blob/master/Source/GoSport.Client/Infrastructure/Filters/ValidPhoneNumberAttribute.cs)
   
### Ajax used for:
  * Loading neighbours when city is choosen
  * Rating sport centers
  * Adding comments
 
### Caching:
  * Caching home pages of sport centers
  * Caching categories
  * Caching neighbours by city
  
### Plugins
 * Kendo grid
 * Kendo autocomplete
 * JQuery images slider
