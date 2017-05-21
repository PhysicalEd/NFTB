$(document).ready(function() {
	if (jQuery.browser.mozilla || jQuery.browser.msie) {
		$(".clickable").each(function() {
			$(this).hover(
			        function() {
			        	$(this).animate({ opacity: 0.8 }, { queue: false, duration: 200 });
			        },
			        function() {
			        	$(this).animate({ opacity: 1.0 }, { queue: false, duration: 200 });
			        }
		        );
		});
		$(".button").each(function() {
			$(this).hover(
	        function() {
	        	$(this).animate({ opacity: 0.8 }, { queue: false, duration: 200 });
	        },
	        function() {
	        	$(this).animate({ opacity: 1.0 }, { queue: false, duration: 200 });
	        }
        );
		
		});

	} 


	$(".loadable").live("click", function() {
		$(this).addClass("loading");
		$(this).disabled = true;
	});

	setTimeout('$(".default").focus();', 500);

	});// End document.ready

	

function pageLoad() {
	if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack()) {
		Sys.WebForms.PageRequestManager.getInstance().add_endRequest(AjaxEnd);
		Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(AjaxBegin);
	}
}
function AjaxEnd(sender, args) {
	$("#postbackprogress").fadeOut();
}

function AjaxBegin(sender, args) {
	$("#postbackprogress").fadeIn();
}


function Focus(elementID) {
	var $container = $("#" + elementID);
	var $input = $container.find('input').eq(0);
	$input.focus();
}
