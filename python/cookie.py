from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.action_chains import ActionChains

base_url = "http://orteil.dashnet.org/cookieclicker/"
click_url = "https://clickspeedtest.com/"
exe_path = r"E:\HK1_Nam4\SoftwareTesting\Record\demo\chrome\chromedriver.exe"

service = Service(exe_path)
options = webdriver.ChromeOptions()
driver = webdriver.Chrome(service=service, options=options)
# driver = webdriver.Chrome(exe_path)

driver.get(click_url)
driver.maximize_window()


driver.implicitly_wait(15) #seconds

# driver.get(base_url)

# chooseLanguage = driver.find_element("id", "langSelect-EN");

# cookie = driver.find_element("id", "bigCookie")
clicker = driver.find_element("clicker");
# cookie_count = driver.find_element("id", "cookies")
# items = [driver.find_element("id", "productPrice" + str(i)) for i in range(1, -1, -1)]
loop = 100
i =0
actions = ActionChains(driver)
while (True):
  actions.click(clicker)
# actions.click(chooseLanguage);
# actions.perform()
# actions.click(cookie)
# actions.perform()

# for i in range(5000):
#   actions.perform()
#   count = int(cookie_count.text.split(" ")[0])
#   for item in items:
#     value = int(item.text)
#     if value <= count:
#       upgrade_actions = ActionChains(driver)
#       upgrade_actions.move_to_element(item)
#       upgrade_actions.click()
#       upgrade_actions.perform()

driver.close()
