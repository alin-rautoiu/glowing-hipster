'use strict';

/* Controllers */
var shoppingListApp = angular.module('shoppingListApp', []);

var visibleAdd = false;
//var visibleEdit = [false,false,false];

shoppingListApp.controller('ShoppingListCtrl', function($scope){
		$scope.categories = ["","Fructe",];
		$scope.lists = [];
		$scope.items = [{item: 'Piersici',details: 'De celea zemoase', check: false, category: "Fructe", editable: false},
						{item: 'Lamai',details: '2', check: false, category: "Fructe", editable: false},
						{item: 'Apa',details: 'plata', check: false, category: "", editable: false}];
		$scope.lists[0] = {index: 0, list: $scope.items};
 		$scope.addItem = function(item){
 			if(item.item != ''){
	 			$scope.items.push({item: item.item,details: item.details, check: false, category: item.category, editable: item.editable});
	 			item.item = '';
	 			item.details = '';
	 			visibleAdd = false;
	 			//visibleEdit.push(false);
	 			var contains = false;
	 			for (var i = $scope.categories.length - 1; i >= 0; i--) {
	 				if($scope.categories[i] == item.category){
	 					contains = true;
	 				}
	 			};
	 			if(contains === false){
	 				$scope.categories.push(item.category);
	 			}
 			}
 		};

 		$scope.click = function(){
 			visibleAdd = true;
 		};
 		$scope.clickEdit = function(input){
 			//visibleEdit[index] = true;
 			input.editable = true;

 		};

 		$scope.isVisible = function(){
 			return visibleAdd;
 		};

 		$scope.isVisibleEdit = function(input){
 			return input.editable;
 		};
 		$scope.editList = function(input,index){
 			var contains = false;
			if(input.item != undefined && input.item != ''){
				
				for (var i = $scope.categories.length - 1; i >= 0; i--) {
	 				if($scope.categories[i] === input.category){
	 					contains = true;
	 				}
	 			};
	 			if(contains === false){
	 				$scope.categories.push(input.category);
	 			}

				input.editable = false;
			}
 		};
 		$scope.clear = function(){
 			for(var i = 0; i < $scope.items.length; i++){
 				if($scope.items[i].check === true){
 					$scope.items.splice(i,1);
 					i--;
 				}
 			}
 		}
 		$scope.newList = function(){
 			$scope.items = [];
 			$scope.lists.push({index: $scope.lists.length, list: $scope.items});
 		}
 		$scope.changeList = function(index){
 			$scope.items = $scope.lists[index].list;
 		}
 });
