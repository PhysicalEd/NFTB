define(['rivets-core', 'jquery', 'lib'], function (rivets, $, lib) {
	// Our configuration
	rivets.configure({ prefix: 'data' });
	
	// Custom formatters etc - this section will get big
	rivets.formatters.negate = function (value) {
		return !value;
	};
	
	return rivets;
});