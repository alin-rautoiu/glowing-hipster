'use strict';

/* Controllers */
var shoppingListApp = angular.module('shoppingListApp', []);

var visibleAdd = false;
var visibleEdit = [false,false,false];

shoppingListApp.controller('ShoppingListCtrl', function($scope){
		$scope.categories = [null,1, 2, 3];
		$scope.lists = [];
		$scope.items = [{item: 'hello',details: 'hello', check: false, category: 1},
						{item: 'hello',details: 'hello', check: false, category: 2},
						{item: 'hello',details: 'hello', check: false, category: 3}];
		$scope.lists[0] = {index: 0, list: $scope.items};
 		$scope.addItem = function(item){
 			if(item.item != ''){
	 			$scope.items.push({item: item.item,details: item.details, check: false, category: item.category});
	 			item.item = '';
	 			item.details = '';
	 			visibleAdd = false;
	 			visibleEdit.push(false);
	 			var contains = false;
	 			for (var i = $scope.categories.length - 1; i >= 0; i--) {
	 				if($scope.categories[i] == item.category){
	 					contains = true;
	 				}
	 			};
	 			if(contains == false){
	 				$scope.categories.push(item.category);
	 			}
 			}
 		};

 		$scope.click = function(){
 			visibleAdd = true;
 		};
 		$scope.clickEdit = function(index){
 			visibleEdit[index] = true;
 		};

 		$scope.isVisible = function(){
 			return visibleAdd;
 		};

 		$scope.isVisibleEdit = function(index){
 			return visibleEdit[index];
 		};
 		$scope.editList = function(input,index){
			if(input.item != undefined){
				$scope.items[index].item = input.item;
				$scope.items[index].details = input.details;
				visibleEdit[index] = false;
			}
 		};
 		$scope.clear = function(){
 			for(var i = 0; i < $scope.items.length; i++){
 				if($scope.items[i].check == true){
 					$scope.items.splice(i,1);
 				}
 			}
 		}
 		$scope.newList = function(){
 			$scope.items = [];
 			$scope.lists.push({index: $scope.lists.length, list: $scope.items});
 		}
 		$scope.changeList = function(index){
 			alert($scope.lists.length);
 			$scope.items = $scope.lists[index].list;
 		}
 });
