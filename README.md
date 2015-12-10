# Shortcut Deep Linking SDK for Windows

This SDK provides the following features:

- Support for [deferred deep linking](https://en.wikipedia.org/wiki/Deferred_deep_linking).
- Collection of additional statistics to build a user acquisition funnel and 
  evaluate user activity.
- Creating Shortcuts (short mobile deep links) to share from within your app.

There are also other versions available
- [iOS version of this SDK](https://github.com/shortcutmedia/shortcut-deeplink-sdk-ios).
- [Android version of this SDK](https://github.com/shortcutmedia/shortcut-deeplink-sdk-android).

## Requirements

The SDK works with any device running Windows Phone 8 or higher.

## Installation


## Prerequisites

To make use of this SDK you need the following:



## Integration into your app


#### Enabling deferred deep linking


#### Collecting deep link interaction statistics

To collect deep link interaction statistics you have to tell the SDK when a deep 
link is opened: The SDK keeps track of your users looking at deep link content 
through sessions. You have to create a session whenever a a deep link is opened; 
the SDK will automatically terminate the session when a user leaves your app.


#### Creating Shortcuts (short mobile deep links)

**Prerequisite:** You need an API key with an authentication token. You can 
generate one in the [Shortcut Manager](http://manager.shortcutmedia.com/users/api_keys). 
We need this in order to identify your app and assign the Shortcut to it..



## License
This project is released under the MIT license. See included LICENSE.txt file for details.