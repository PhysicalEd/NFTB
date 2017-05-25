define(['jquery'], function ($) {
	var
		
		
		BindView = function (model, controller) {

			require(['rivets'], function (rivets) {
				var viewID = model.UniqueID;
				var view = document.getElementById(viewID);
				var rivetsView = rivets.bind(view, new controller(model));
				model.__rivets = rivetsView;
			});
		},
		OnRequestComplete = function (requestIsUserActivated) {
			if (requestIsUserActivated == undefined) requestIsUserActivated = true;

			if (requestIsUserActivated) {
				var $loadings = $(".loading");

				$loadings.each(function () {
					$(this).removeClass("loading");
				});
			}
		},
		Data = function() {
			var callCount = 0,
				SiteRoot = '/',
				FormatUrl = function(route, params) {

					// Create route if not explicitly defined
					var url = '';
					if (route.indexOf('http') == 0) {
						url = route;
					}else{
						if (route[0] == '/') route = route.substring(1);
						url = SiteRoot;
						if (url == undefined) url = '/';
						url += route;
					}
					if (params == null) params = {};

					// Append parameters
					if (url.indexOf('?') == -1) url += '?';
					for (var key in params) {
						var sKey = encodeURIComponent(key);
						var sValue = encodeURIComponent(params[key]);
						url += '&' + sKey + '=' + sValue;
					}
					return url;
				};
			return {
				CallView: function(route, params, callback, usePost) {
					if (usePost == undefined) usePost = true;
					if (typeof (params) === "undefined" || params === null) params = {};
					
					var postType = usePost ? 'POST' : 'GET';
					var url = usePost ? FormatUrl(route, {}) : FormatUrl(route, params);
					$.ajax({
						url: url,
						data: usePost ? params : {},
						type: postType,
						dataType: "html",
						success: function(html) {
							OnRequestComplete();
							if (callback != undefined) callback(html);
						}
					});
				},

				CallJSON: function(route, params, callback, callingContainerID) {
					// When we call from within our own site, we can POST because it is the same domain - this allows much larger params to be sent
					var useGET = false;

					if (route[0] == '/') route = route.substring(1);

					if (params == null) params = {};

					// Make the JSON call
					var fn_jsonp_request = function(ajaxUrl, data) {
						$.ajax({
							url: url,
							data: data,
							type: (useGET ? 'GET' : 'POST'),
							dataType: "json",
							success: function(x, y, z) {
								if (typeof (callback) === "function") callback(x);
							}
						});
					};

					// Request too long, we have to POST
					var url = '';
					url = FormatUrl(route, null);
					fn_jsonp_request(url, params);
				},

				OnCallJSON: function(result, triggerName, callingContainerID) {
					$("body").trigger(triggerName, result);
					$("body").unbind(triggerName);
				},

				OnCallJSONError: function(messages, triggerName, callingContainerID) {
					OnRequestComplete();
					alert(messages);
				}
			};
		}()
		;

	return {
		BindView: BindView,
		OnRequestComplete: OnRequestComplete,
		Data: Data
	};
});