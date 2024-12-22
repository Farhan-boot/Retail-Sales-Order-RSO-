$(document).ready(function(){        
    $('li img').on('click', function () {

        var src = $(this).attr('src');
        
        var title = $(this).attr('data-title'); 
        var altSerial = $(this).attr('alt');
		var img = '<img src="' + src + '" class="img-responsive"/>';
		
		//start of new code new code
		var index = $(this).parent('li').index();
       
		//alert(altSerial);
		
		var html = '';
		html += img;                
		html += '<div style="height:25px;clear:both;display:block;">';
		html += '<a class="controls next" href="' + (parseInt(altSerial) + 1) + '">next &raquo;</a>';
		html += '<a class="controls previous" href="' + (parseInt(altSerial) - 1) + '">&laquo; prev</a>';
		html += '</div>';
		
		$('#myModal .modal-title').html(title);
		//$('.modal-body img').attr('src', src);

		$('#myModal').modal();

		$('#myModal').on('shown.bs.modal', function(){
			$('#myModal .modal-body').html(html);
			//new code
			$('a.controls').trigger('click');
			$('#myModal .modal-title').html(title);
		})

		$('#myModal').on('hidden.bs.modal', function(){
		    $('#myModal .modal-body').html('');
		    $('#myModal .modal-title').html(title);
		});

		
		
		
		
   });	
})
        
         
$(document).on('click', 'a.controls', function(){
	var index = $(this).attr('href');
	var src = $('ul.row li:nth-child('+ index +') img').attr('src');             

	var title = $('ul.row li:nth-child(' + index + ') img').attr('data-title');
	$('#myModal .modal-title').html(title);

	$('.modal-body img').attr('src', src);
	
	var newPrevIndex = parseInt(index) - 1; 
	var newNextIndex = parseInt(newPrevIndex) + 2; 
	
	if($(this).hasClass('previous')){               
		$(this).attr('href', newPrevIndex); 
		$('a.next').attr('href', newNextIndex);
	}else{
		$(this).attr('href', newNextIndex); 
		$('a.previous').attr('href', newPrevIndex);
	}
	
	var total = $('ul.row li').length + 1; 
	//hide next button
	if(total === newNextIndex){
		$('a.next').hide();
	}else{
		$('a.next').show()
	}            
	//hide previous button
	if(newPrevIndex === 0){
		$('a.previous').hide();
	}else{
		$('a.previous').show()
	}
	
	
	return false;
});