#Business Search      URL -- 'https://api.yelp.com/v3/businesses/search'
#Business Match       URL -- 'https://api.yelp.com/v3/businesses/matches'
#Phone Search         URL -- 'https://api.yelp.com/v3/businesses/search/phone'

#Business Details     URL -- 'https://api.yelp.com/v3/businesses/{id}'
#Business Reviews     URL -- 'https://api.yelp.com/v3/businesses/{id}/reviews'

import requests
from YelpAPIKey import get_my_key

#define API Key
API_KEY = get_my_key()
ENDPOINT = 'https://api.yelp.com/v3/businesses/search'
Headers = {'Authorization': 'bearer %s' % API_KEY}



#define parameters
PARAMETERS = {'term':'coffee',                         #Term is the keyword for the lookup
              'limit':50,                               #How many businesses
              'radius':10000,                            #Radius is in Meters
              'location': 'San Bernardino'}            #TODO: Change all of these for vals relative to the user

#Make request to yelp API

response = requests.get(url = ENDPOINT, params= PARAMETERS, headers= Headers)

if response.status_code == 200:
    data = response.json()
    businesses = data.get('businesses', [])

    for business in businesses:
        print(f"Name: {business['name']}")
        print(f"Business ID: {business['id']}")
        print(f"Is Closed: {business['is_closed']}")
        print(f"Rating: {business['rating']}")
        print(f"Image: {business['image_url']}")
        # print(f": {business['']}")

        #location 
        location = business['location']
        address = location.get('address1', '')
        city = location.get('city', '')
        state = location.get('state', '')
        zipCode = location.get('zip_code', '')

        full_address = f'Address: {address}, {city}, {state}, {zipCode}'
        print(full_address)


        print("")
else:
    print(f"Error")








#convert JSON from yelp to python
# business_data = response.json()
# print(business_data)


#Full List of Params
# PARAMETERS = {'term':'food',
#               'location':'San Bernardino',
#               'state':'CA'
#               'latitude':'32.123456',
#               'longitude':'-117.123456',
#               'radius':'10000',                 #meters
#               'categories':'bars',
#               'limit':50,
#               'offset':50,
#               'sort_by':'best_match',
#               'price': '1',                      #1-4 1 cheap 4 expensive
#               'open_now': True,
#               'attributes':'hot_and_new'
#               }