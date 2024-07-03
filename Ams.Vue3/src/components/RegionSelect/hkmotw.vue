<template>
  <div>
    <p>當前您選擇了: {{form.province}}-{{form.city}}-{{form.region}}-{{form.street}}</p>
    <el-form>
      <el-form-item label="行政區劃">
        <div>
          <el-select clearable filterable v-model="form.province" placeholder="區域" @change="changePr">
            <el-option v-for="item in provinceList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.city" placeholder="區域" @change="changeCi">
            <el-option v-for="item in cityList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.region" placeholder="區域" @change="changeRe">
            <el-option v-for="item in regionList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>
          <el-select clearable filterable v-model="form.street" placeholder="區域" @change="changeSt">
            <el-option v-for="item in streetList" :key="item.code" :label="item.label" :value="item.name">
            </el-option>
          </el-select>

        </div>
      </el-form-item>
    </el-form>
  </div>
</template>

<script setup name="regionHkmotwData">
  import pacas from './hkmotw.json'

  let data = pacas;//格式化后的json字符串形式
  let form = ref({
    province: '', // 行政区划——省市自治区
    city: '', // 行政区划——市地区
    region: '', // 行政区划——区县
    street: '', // 行政区划——乡镇街道

  })
  let provinceList = ref([]) // 存放省市自治区数据集合
  let cityList = ref([]) // 存放市地区数据集合
  let regionList = ref([]) // 存放区县数据集合
  let streetList = ref([]) //存放乡镇街道数据集合


  onMounted(() => {
    //获取省
    provinceList.value = data
  })
  //获取省
  const changePr = () => {
    for (var key of data) {
      if (key.name == form.value.province) {
        cityList.value = key.children
        form.value.city = key.children[0].name //默认选择第一个显示
      }
    }
    changeCi()
    changeRe()

  }
  //获取省
  const changeCi = () => {
    cityList.value.forEach((item, index) => {
      if (item.name == form.value.city) {
        regionList.value = item.children
        form.value.region = item.children[0].name //默认选择第一个显示
      }
    })
    changeRe()

  }
  //获取
  const changeRe = () => {
    console.log(regionList)
    regionList.value.forEach((item1, index1) => {
      if (item1.name == form.value.region) {
        streetList.value = item1.children
        form.value.street = item1.children[0].name  //默认选择第一个显示
        return;
      }
    })

  }



</script>

<style>
</style>