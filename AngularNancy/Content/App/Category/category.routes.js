(function () {

	angular
		.module('app.category')
		.config(categoryConfig);

	function categoryConfig($stateProvider) {

		var categories = {
			name: 'categories',
			url: '/categories',
			template: "'<div ui-view></div>'"
		};
		var categorylist = {
			name: 'categories.list',
			url: '/categories',
			templateUrl: 'Content/App/Category/list.html',
			controller: 'CategoryListController',
			controllerAs: 'vm'
		};
		var viewCategory = {
			name: 'categories.view',
			url: '/:categoryID',
			templateUrl: 'Content/App/Category/view.html',
			controller: 'CategoryViewController',
			controllerAs: 'vm'
		}

	};

})();