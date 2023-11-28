	1. ViewBag, ViewData, TempData is used to Transfer Data from Controller to View.
		ViewBag Makes Dynamic Variable.
		ViewData Makes Key-Value Pair = ["Key"] = Value.
		TempData 

	1. **Model:** Represents data and business logic. It interacts with the database, processes data, and sends it to the view.

	2. **View:** Displays the user interface. It presents data from the model and sends user input back to the controller.

	3. **Controller:** Manages user input, updates the model, and selects the view. It handles the application's overall flow and logic.

	4. **ViewModel:** A bridge between the model and view. It shapes data for the view's needs without altering the underlying model.

	5. **ViewBag:** A dynamic property bag for passing data from the controller to the view. It is part of the ViewData dictionary.

	6. **ViewData:** A dictionary for passing data from the controller to the view. It is used for communication between the controller and view.

	7. **TempData:** Stores data for the duration of an HTTP request, making it available across redirects. Useful for one-time messages or data.

	8. **Session:** Stores user-specific information that persists across multiple requests. It enables maintaining state information for a user during a session.