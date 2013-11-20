var hideOnClick = function(){
	$(this).html('');
	var non_empty_cells_count = 0;
	
	$(this).siblings().each(function(){
		if($(this).html() !== ''){
			non_empty_cells_count++;	
		}
	});

	if(non_empty_cells_count === 0) {
		$(this).parent().hide();
	}
}

$(function(){
	$('#adaugare').click(function(){
		$('.formular').show();
	});

	$('#submit').click(function(e){
		e.preventDefault();
		$('.mainTable tr:last').after(
		'<tr><td id="name">'+ $('#name_form').val() + '</td><td id="prenume">'+ $('#surname_form').val() +'</td><td id="varsta">'+$('#age_form').val() +'</td><td id="departament">'+$('#dep_form').val() + '</td><td id="angajare">'+$('#date_form').val() + '</td><td id="post">'+$('#post_form').val()+'</td><td>'
			);
		$('#name_form').val('');
		$('#surname_form').val('');
		$('#age_form').val('');
		$('#dep_form').val('');
		$('#date_form').val('');
		$('#post_form').val('');
		$('.formular').fadeOut();
		
		$('.mainTable tr:last td').click(hideOnClick);
	});

	$('.mainTable td').click(hideOnClick);
});