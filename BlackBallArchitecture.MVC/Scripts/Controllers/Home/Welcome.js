define(['lib'], function (lib) {
	return function (model) {
		var
			Init = function () {
				console.log("People", model);
			},
			ViewPerson = function(ev, data) {
				alert('You have clicked ' + data.person.DisplayName);
			},
			AddPerson = function () {
				var params = {
					firstName: 'Person ' + (model.People.length + 1)
				};

				// Call our MVC controller method
				lib.Data.CallJSON('home/createperson', params, function (newPerson) {
					
					// Add to our model - the view will update automatically
					model.People.push(newPerson);
				});

				return false;
			};

		Init();
		return {
			model: model,
			AddPerson: AddPerson,
			ViewPerson: ViewPerson
		};
	};
});