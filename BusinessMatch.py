#Business Search      URL -- 'https://api.yelp.com/v3/businesses/search'
#Business Match       URL -- 'https://api.yelp.com/v3/businesses/matches'
#Phone Search         URL -- 'https://api.yelp.com/v3/businesses/search/phone'

#Business Details     URL -- 'https://api.yelp.com/v3/businesses/{id}'
#Business Reviews     URL -- 'https://api.yelp.com/v3/businesses/{id}/reviews'

import requests
# import IDSearch
def get_business_details():
    from YelpAPIKey import get_my_key
    business_id = ""                                        #TODO get the ID from the business search
    
    
    #define API Key
    API_KEY = get_my_key()
    ENDPOINT = 'https://api.yelp.com/v3/businesses/{}'.format(business_id)
    Headers = {'Authorization': 'bearer %s' % API_KEY}


    #define parameters
    PARAMETERS = {'term':'coffee',                         #TODO: Change all of these for vals relative to the user
                'limit':5,                               
                'radius':10000,                            
                'location': 'San Bernardino'}            


    #Make request to yelp API
    response = requests.get(url = ENDPOINT, params= PARAMETERS, headers= Headers)


    #convert JSON from yelp to python
    if response.status_code == 200:
        business_data = response.json()
        print(business_data)
        return business_data
    else:
        print(f"Error")
        return None
