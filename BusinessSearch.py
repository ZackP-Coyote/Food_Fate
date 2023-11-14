#Business Search      URL -- 'https://api.yelp.com/v3/businesses/search'
#Business Match       URL -- 'https://api.yelp.com/v3/businesses/matches'
#Phone Search         URL -- 'https://api.yelp.com/v3/businesses/search/phone'

#Business Details     URL -- 'https://api.yelp.com/v3/businesses/{id}'
#Business Reviews     URL -- 'https://api.yelp.com/v3/businesses/{id}/reviews'

import requests
import random
from YelpAPIKey import get_my_key

#define API Key
API_KEY = get_my_key()
ENDPOINT = 'https://api.yelp.com/v3/businesses/search'
Headers = {'Authorization': 'bearer %s' % API_KEY}



#define parameters
PARAMETERS = {'term':'coffee',                         #Term is the keyword for the lookup
              'limit':5,                               #How many businesses
              'radius':10000,                            #Radius is in Meters
              'location': 'San Bernardino'}            #TODO: Change all of these for vals relative to the user
all_businessInfo = []
num_businesses = PARAMETERS['limit']
#Make request to yelp API

response = requests.get(url = ENDPOINT, params= PARAMETERS, headers= Headers)

if response.status_code == 200:
    data = response.json()
    businesses = data.get('businesses', [])

    for business in businesses:     
        business_set = [
            business['id'],
            business['name'],
            business['is_closed'],
            business['rating'],
            business['image_url'],
            business['location']['address1']
        ]
        all_businessInfo.append(business_set)
        

else:
    print(f"Error")


# Testing for randomization
# for i in range(num_businesses):
#     print(all_businessInfo[i])
#     print("\n")

# random.shuffle(all_businessInfo)
# print("--------------------")
# for i in range(num_businesses):
#     print(all_businessInfo[i])
#     print("\n")

random.shuffle(all_businessInfo)





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

#getting business data
        # print(f"Name: {business['name']}")
        # print(f"Business ID: {business['id']}")
        # print(f"Is Closed: {business['is_closed']}")
        # print(f"Rating: {business['rating']}")
        # print(f"Image: {business['image_url']}")
        # # print(f": {business['']}")
        

        # #location 
        # location = business['location']
        # address = location.get('address1', '')
        # city = location.get('city', '')
        # state = location.get('state', '')
        # zipCode = location.get('zip_code', '')

        # full_address = f'Address: {address}, {city}, {state}, {zipCode}'
        # print(full_address)
