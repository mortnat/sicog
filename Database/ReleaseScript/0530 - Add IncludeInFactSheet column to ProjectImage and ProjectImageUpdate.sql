alter table dbo.ProjectImage add IncludeInFactSheet bit null
alter table dbo.ProjectImageUpdate add IncludeInFactSheet bit null

go
update dbo.ProjectImage set IncludeInFactSheet = 0 where ExcludeFromFactSheet = 1
update dbo.ProjectImageUpdate set IncludeInFactSheet = 0 where ExcludeFromFactSheet = 1

-- update ProjectImages that would be included in the fact sheet based on the algorithm in the C# code
update dbo.ProjectImage set IncludeInFactSheet = 1 where ProjectImageID in (1326, 2, 1173, 4, 5, 7, 39, 43, 1322, 1324, 51, 54, 56, 1220, 60, 76, 78, 79, 80,
81, 83, 84, 2397, 2398, 2399, 2400, 2394, 2395, 2396, 88, 89, 91, 92, 106, 107, 94, 96, 99, 98, 101, 97, 100, 1149, 111, 110, 108, 112, 114, 115, 116, 1115, 
1114, 1117, 2402, 2403, 2404, 2414, 4670, 4671, 4672, 4673, 2415, 1211, 1119, 1120, 1122, 1123, 1125, 5159, 5160, 5164, 5165, 5166, 5167, 1127, 4689, 1129, 1130,
1131, 1132, 1136, 1137, 4690, 4692, 1157, 1159, 1160, 1331, 1332, 1334, 1164, 1163, 1162, 1166, 1169, 2418, 4901, 4902, 1171, 5386, 1175, 1316, 1176, 1178, 1179,
1180, 1181, 1182, 1184, 1187, 1188, 1190, 1191, 1193, 1194, 4898, 4896, 4897, 1216, 1217, 4885, 4880, 4881, 4886, 1310, 1311, 1312, 1313, 1314, 1224, 1225, 1226,
1228, 1227, 1229, 4384, 2473, 1251, 1252, 1269, 3529, 3528, 1276, 1277, 1307, 1308, 1319, 1320, 1328, 1335, 2390, 2391, 2392, 2393, 1337, 1338, 1340, 1342, 4171,
1369, 1371, 1366, 1368, 3489, 3491, 1343, 1347, 1349, 1345, 1346, 1352, 1354, 1351, 1353, 4080, 1360, 1361, 1363, 2378, 3691, 3692, 4817, 4809, 2386, 2421, 2422,
2423, 2425, 2426, 4493, 4614, 4615, 2430, 4601, 4486, 2434, 3590, 4459, 4466, 4458, 4467, 4464, 4465, 4253, 4357, 4360, 3664, 3644, 4773, 4771, 4769, 4770, 2436,
3548, 3545, 3546, 4379, 4378, 4382, 4380, 4381, 2438, 2439, 2440, 2441, 4265, 4269, 3471, 3473, 3474, 2446, 2445, 2444, 2447, 4256, 3537, 4348, 2452, 4090, 4092,
4093, 4786, 3953, 4141, 4142, 4350, 4354, 2456, 2457, 2458, 4375, 4757, 4758, 4989, 3495, 3496, 3504, 2466, 2467, 2468, 3499, 3500, 3501, 3502, 3517, 3518, 3515,
3516, 3521, 3522, 3509, 3510, 3511, 4524, 4523, 4528, 4529, 4496, 4495, 4516, 4517, 4508, 4511, 4509, 4510, 4531, 4532, 4513, 4514, 4515, 4491, 4535, 4536, 4520,
4533, 4521, 3619, 3620, 3621, 3595, 3593, 3592, 3607, 4193, 4196, 4194, 4195, 3638, 3636, 3637, 3639, 3560, 3557, 3558, 3572, 3573, 3571, 3534, 3535, 3533, 4538,
4407, 4488, 4406, 4487, 4492, 3656, 3660, 3596, 3597, 3541, 3539, 3540, 4270, 4502, 4501, 4503, 3582, 4202, 3583, 3562, 3564, 3568, 3569, 3566, 3567, 3576, 3577,
3579, 3580, 3667, 3668, 3779, 5037, 5038, 4164, 4167, 5034, 5043, 3670, 3671, 4170, 3604, 3605, 3606, 3624, 3626, 3628, 3629, 3633, 3631, 3632, 3647, 3648, 3650,
3651, 3653, 3654, 3694, 3683, 3685, 3684, 3687, 3688, 3702, 3703, 3697, 3699, 3707, 3709, 3710, 3711, 3701, 3772, 3719, 3724, 3781, 3726, 3727, 3734, 3737, 3739,
3740, 3742, 3743, 3744, 3745, 3748, 4541, 4812, 4813, 3757, 3758, 3762, 3761, 3755, 3754, 3756, 3768, 3767, 3769, 3771, 4790, 4789, 4788, 4076, 4078, 4074, 4029,
4081, 4082, 4059, 4060, 4054, 3969, 3970, 3971, 3972, 4994, 4995, 5301, 4565, 5277, 5278, 4484, 4701, 4569, 5421, 4221, 4471, 4472, 4473, 6481, 6482, 6483, 4571,
3987, 4573, 4574, 4477, 5388, 5389, 5391, 5392, 4480, 4481, 4482, 4483, 5416, 4475, 5419, 4479, 5393, 5395, 4553, 4850, 4851, 4153, 4154, 4156, 4157, 5186, 5187,
5207, 5194, 5195, 4563, 5072, 5074, 5075, 5076, 5077, 5078, 4926, 4927, 4844, 4845, 4929, 4033, 4034, 4550, 4551, 5000, 4996, 4070, 4071, 4072, 5030, 4002, 4003,
4006, 4000, 3966, 3964, 3967, 4036, 4037, 5007, 5008, 3994, 3995, 4088, 4009, 4010, 4015, 4016, 4008, 3997, 3998, 3996, 3955, 3956, 3958, 3959, 3957, 4463, 4462,
4987, 4988, 4870, 4869, 4026, 5003, 5001, 5002, 5004, 5005, 5006, 4309, 4892, 5019, 3929, 3927, 3928, 4992, 5016, 5417, 6485, 6486, 6487, 4848, 4849, 5420, 4873,
4874, 4876, 4877, 4222, 4031, 4017, 4018, 3932, 3933, 3934, 5302, 5303, 3974, 3973, 4435, 4453, 4436, 4456, 4452, 4454, 3893, 3895, 3894, 3896, 3897, 3900, 3902,
3903, 3982, 3992, 4255, 4830, 4831, 4832, 4833, 4096, 4104, 4105, 4097, 4099, 4101, 4102, 4103, 4100, 4134, 4135, 4107, 4110, 4111, 4112, 4113, 4116, 4120, 4121,
4122, 4125, 4124, 4126, 4127, 4128, 4130, 4131, 4137, 4139, 4138, 4147, 4146, 4542, 4543, 4544, 4150, 4151, 4152, 4174, 4179, 4178, 4175, 4180, 4162, 4163, 4211,
4212, 4210, 4185, 4914, 4266, 4351, 4352, 4613, 4916, 4198, 4199, 4200, 4201, 4204, 4213, 4235, 4236, 4285, 4278, 4279, 4280, 4281, 4274, 4275, 4415, 4414, 4416,
4277, 4739, 4740, 4294, 4326, 4343, 4346, 4292, 4327, 4301, 4300, 4336, 4304, 4347, 4341, 4921, 4317, 4320, 4334, 4325, 4625, 4368, 4367, 4366, 4369, 4370, 4372,
4373, 4861, 4864, 4865, 4862, 4863, 4374, 4387, 4612, 4915, 4619, 4620, 4621, 4622, 4623, 4425, 4628, 4793, 4802, 4932, 4934, 4807, 4806, 4953, 4954, 4410, 4413,
4409, 4411, 4762, 4763, 4764, 4765, 4426, 5067, 5069, 5070, 4504, 4505, 4599, 4497, 4499, 4446, 4448, 4470, 4810, 4526, 4540, 4546, 4547, 4548, 4549, 4811, 4558,
4559, 4561, 4586, 4587, 4577, 4578, 4857, 4858, 4860, 4592, 4594, 4595, 4596, 4657, 4630, 4638, 4797, 4798, 4633, 6516, 6517, 4635, 4636, 4637, 4676, 4677, 4698,
4699, 4642, 4646, 4641, 4643, 4647, 4649, 4650, 4648, 4651, 4659, 4889, 4910, 4911, 4665, 4693, 4694, 4696, 4697, 4917, 4918, 4667, 4669, 4679, 4685, 4723, 4710,
4711, 4713, 4714, 4715, 4716, 4742, 4743, 4744, 4745, 4748, 4750, 4747, 4749, 4720, 4721, 4725, 4726, 4735, 4760, 4761, 4775, 4776, 4778, 4779, 4781, 4784, 4824,
4822, 5096, 5097, 4826, 4827, 4828, 4829, 4838, 4835, 4836, 4840, 4837, 4853, 4907, 4908, 4990, 5024, 5346, 5347, 5349, 5350, 5348, 5368, 5369, 5372, 5374, 5362,
5364, 5367, 5378, 5379, 5381, 5383, 5382, 4961, 4960, 4959, 4962, 4958, 4923, 4924, 4974, 4965, 4966, 4977, 4978, 4982, 4983, 4984, 4985, 4986, 5023, 5027, 5046,
5047, 5051, 5049, 5050, 5055, 5056, 5059, 5087, 5088, 5090, 5091, 5093, 5114, 5115, 5116, 5117, 5130, 5131, 5133, 5098, 5135, 5136, 5100, 5101, 5102, 5103, 5104,
5210, 5106, 5107, 5109, 5110, 5314, 5315, 5316, 5318, 5317, 5356, 5358, 5360, 5357, 5361, 5304, 5351, 5353, 5354, 5340, 5341, 5342, 5343, 5344, 5262, 5263, 5264,
5266, 5261, 5332, 5333, 5338, 5334, 5335, 5324, 5320, 5321, 5147, 5148, 5228, 5230, 5231, 5150, 5152, 5149, 5154, 5155, 5156, 5174, 5176, 5177, 5178, 5181, 5185,
5184, 5213, 5215, 5216, 5214, 5221, 5219, 5218, 5220, 5223, 5224, 5225, 5226, 5233, 5235, 5236, 5238, 5241, 5242, 5267, 5269, 5271, 5272, 5274, 5283, 5282, 5281,
5284, 5300, 5286, 5292, 5288, 5290, 5291, 6510, 6511, 6512, 6515, 6518, 5296, 5409, 5410, 5402, 5401, 5403, 5404, 5411, 5413, 5414, 5427, 5428, 5429, 5430, 5424,
5425, 6430, 6492, 6494, 6489, 6493, 6495, 6499, 6506, 6525, 6526, 6527, 6523, 6524, 6500, 6501, 6502, 6504)

update dbo.ProjectImageUpdate set IncludeInFactSheet = 1 where ProjectImageID in (1326, 2, 1173, 4, 5, 7, 39, 43, 1322, 1324, 51, 54, 56, 1220, 60, 76, 78, 79, 80,
81, 83, 84, 2397, 2398, 2399, 2400, 2394, 2395, 2396, 88, 89, 91, 92, 106, 107, 94, 96, 99, 98, 101, 97, 100, 1149, 111, 110, 108, 112, 114, 115, 116, 1115, 
1114, 1117, 2402, 2403, 2404, 2414, 4670, 4671, 4672, 4673, 2415, 1211, 1119, 1120, 1122, 1123, 1125, 5159, 5160, 5164, 5165, 5166, 5167, 1127, 4689, 1129, 1130,
1131, 1132, 1136, 1137, 4690, 4692, 1157, 1159, 1160, 1331, 1332, 1334, 1164, 1163, 1162, 1166, 1169, 2418, 4901, 4902, 1171, 5386, 1175, 1316, 1176, 1178, 1179,
1180, 1181, 1182, 1184, 1187, 1188, 1190, 1191, 1193, 1194, 4898, 4896, 4897, 1216, 1217, 4885, 4880, 4881, 4886, 1310, 1311, 1312, 1313, 1314, 1224, 1225, 1226,
1228, 1227, 1229, 4384, 2473, 1251, 1252, 1269, 3529, 3528, 1276, 1277, 1307, 1308, 1319, 1320, 1328, 1335, 2390, 2391, 2392, 2393, 1337, 1338, 1340, 1342, 4171,
1369, 1371, 1366, 1368, 3489, 3491, 1343, 1347, 1349, 1345, 1346, 1352, 1354, 1351, 1353, 4080, 1360, 1361, 1363, 2378, 3691, 3692, 4817, 4809, 2386, 2421, 2422,
2423, 2425, 2426, 4493, 4614, 4615, 2430, 4601, 4486, 2434, 3590, 4459, 4466, 4458, 4467, 4464, 4465, 4253, 4357, 4360, 3664, 3644, 4773, 4771, 4769, 4770, 2436,
3548, 3545, 3546, 4379, 4378, 4382, 4380, 4381, 2438, 2439, 2440, 2441, 4265, 4269, 3471, 3473, 3474, 2446, 2445, 2444, 2447, 4256, 3537, 4348, 2452, 4090, 4092,
4093, 4786, 3953, 4141, 4142, 4350, 4354, 2456, 2457, 2458, 4375, 4757, 4758, 4989, 3495, 3496, 3504, 2466, 2467, 2468, 3499, 3500, 3501, 3502, 3517, 3518, 3515,
3516, 3521, 3522, 3509, 3510, 3511, 4524, 4523, 4528, 4529, 4496, 4495, 4516, 4517, 4508, 4511, 4509, 4510, 4531, 4532, 4513, 4514, 4515, 4491, 4535, 4536, 4520,
4533, 4521, 3619, 3620, 3621, 3595, 3593, 3592, 3607, 4193, 4196, 4194, 4195, 3638, 3636, 3637, 3639, 3560, 3557, 3558, 3572, 3573, 3571, 3534, 3535, 3533, 4538,
4407, 4488, 4406, 4487, 4492, 3656, 3660, 3596, 3597, 3541, 3539, 3540, 4270, 4502, 4501, 4503, 3582, 4202, 3583, 3562, 3564, 3568, 3569, 3566, 3567, 3576, 3577,
3579, 3580, 3667, 3668, 3779, 5037, 5038, 4164, 4167, 5034, 5043, 3670, 3671, 4170, 3604, 3605, 3606, 3624, 3626, 3628, 3629, 3633, 3631, 3632, 3647, 3648, 3650,
3651, 3653, 3654, 3694, 3683, 3685, 3684, 3687, 3688, 3702, 3703, 3697, 3699, 3707, 3709, 3710, 3711, 3701, 3772, 3719, 3724, 3781, 3726, 3727, 3734, 3737, 3739,
3740, 3742, 3743, 3744, 3745, 3748, 4541, 4812, 4813, 3757, 3758, 3762, 3761, 3755, 3754, 3756, 3768, 3767, 3769, 3771, 4790, 4789, 4788, 4076, 4078, 4074, 4029,
4081, 4082, 4059, 4060, 4054, 3969, 3970, 3971, 3972, 4994, 4995, 5301, 4565, 5277, 5278, 4484, 4701, 4569, 5421, 4221, 4471, 4472, 4473, 6481, 6482, 6483, 4571,
3987, 4573, 4574, 4477, 5388, 5389, 5391, 5392, 4480, 4481, 4482, 4483, 5416, 4475, 5419, 4479, 5393, 5395, 4553, 4850, 4851, 4153, 4154, 4156, 4157, 5186, 5187,
5207, 5194, 5195, 4563, 5072, 5074, 5075, 5076, 5077, 5078, 4926, 4927, 4844, 4845, 4929, 4033, 4034, 4550, 4551, 5000, 4996, 4070, 4071, 4072, 5030, 4002, 4003,
4006, 4000, 3966, 3964, 3967, 4036, 4037, 5007, 5008, 3994, 3995, 4088, 4009, 4010, 4015, 4016, 4008, 3997, 3998, 3996, 3955, 3956, 3958, 3959, 3957, 4463, 4462,
4987, 4988, 4870, 4869, 4026, 5003, 5001, 5002, 5004, 5005, 5006, 4309, 4892, 5019, 3929, 3927, 3928, 4992, 5016, 5417, 6485, 6486, 6487, 4848, 4849, 5420, 4873,
4874, 4876, 4877, 4222, 4031, 4017, 4018, 3932, 3933, 3934, 5302, 5303, 3974, 3973, 4435, 4453, 4436, 4456, 4452, 4454, 3893, 3895, 3894, 3896, 3897, 3900, 3902,
3903, 3982, 3992, 4255, 4830, 4831, 4832, 4833, 4096, 4104, 4105, 4097, 4099, 4101, 4102, 4103, 4100, 4134, 4135, 4107, 4110, 4111, 4112, 4113, 4116, 4120, 4121,
4122, 4125, 4124, 4126, 4127, 4128, 4130, 4131, 4137, 4139, 4138, 4147, 4146, 4542, 4543, 4544, 4150, 4151, 4152, 4174, 4179, 4178, 4175, 4180, 4162, 4163, 4211,
4212, 4210, 4185, 4914, 4266, 4351, 4352, 4613, 4916, 4198, 4199, 4200, 4201, 4204, 4213, 4235, 4236, 4285, 4278, 4279, 4280, 4281, 4274, 4275, 4415, 4414, 4416,
4277, 4739, 4740, 4294, 4326, 4343, 4346, 4292, 4327, 4301, 4300, 4336, 4304, 4347, 4341, 4921, 4317, 4320, 4334, 4325, 4625, 4368, 4367, 4366, 4369, 4370, 4372,
4373, 4861, 4864, 4865, 4862, 4863, 4374, 4387, 4612, 4915, 4619, 4620, 4621, 4622, 4623, 4425, 4628, 4793, 4802, 4932, 4934, 4807, 4806, 4953, 4954, 4410, 4413,
4409, 4411, 4762, 4763, 4764, 4765, 4426, 5067, 5069, 5070, 4504, 4505, 4599, 4497, 4499, 4446, 4448, 4470, 4810, 4526, 4540, 4546, 4547, 4548, 4549, 4811, 4558,
4559, 4561, 4586, 4587, 4577, 4578, 4857, 4858, 4860, 4592, 4594, 4595, 4596, 4657, 4630, 4638, 4797, 4798, 4633, 6516, 6517, 4635, 4636, 4637, 4676, 4677, 4698,
4699, 4642, 4646, 4641, 4643, 4647, 4649, 4650, 4648, 4651, 4659, 4889, 4910, 4911, 4665, 4693, 4694, 4696, 4697, 4917, 4918, 4667, 4669, 4679, 4685, 4723, 4710,
4711, 4713, 4714, 4715, 4716, 4742, 4743, 4744, 4745, 4748, 4750, 4747, 4749, 4720, 4721, 4725, 4726, 4735, 4760, 4761, 4775, 4776, 4778, 4779, 4781, 4784, 4824,
4822, 5096, 5097, 4826, 4827, 4828, 4829, 4838, 4835, 4836, 4840, 4837, 4853, 4907, 4908, 4990, 5024, 5346, 5347, 5349, 5350, 5348, 5368, 5369, 5372, 5374, 5362,
5364, 5367, 5378, 5379, 5381, 5383, 5382, 4961, 4960, 4959, 4962, 4958, 4923, 4924, 4974, 4965, 4966, 4977, 4978, 4982, 4983, 4984, 4985, 4986, 5023, 5027, 5046,
5047, 5051, 5049, 5050, 5055, 5056, 5059, 5087, 5088, 5090, 5091, 5093, 5114, 5115, 5116, 5117, 5130, 5131, 5133, 5098, 5135, 5136, 5100, 5101, 5102, 5103, 5104,
5210, 5106, 5107, 5109, 5110, 5314, 5315, 5316, 5318, 5317, 5356, 5358, 5360, 5357, 5361, 5304, 5351, 5353, 5354, 5340, 5341, 5342, 5343, 5344, 5262, 5263, 5264,
5266, 5261, 5332, 5333, 5338, 5334, 5335, 5324, 5320, 5321, 5147, 5148, 5228, 5230, 5231, 5150, 5152, 5149, 5154, 5155, 5156, 5174, 5176, 5177, 5178, 5181, 5185,
5184, 5213, 5215, 5216, 5214, 5221, 5219, 5218, 5220, 5223, 5224, 5225, 5226, 5233, 5235, 5236, 5238, 5241, 5242, 5267, 5269, 5271, 5272, 5274, 5283, 5282, 5281,
5284, 5300, 5286, 5292, 5288, 5290, 5291, 6510, 6511, 6512, 6515, 6518, 5296, 5409, 5410, 5402, 5401, 5403, 5404, 5411, 5413, 5414, 5427, 5428, 5429, 5430, 5424,
5425, 6430, 6492, 6494, 6489, 6493, 6495, 6499, 6506, 6525, 6526, 6527, 6523, 6524, 6500, 6501, 6502, 6504)

--also set key photos as Include In Fact Sheet, since those are in the Fact Sheet (just highlighted). Seems less confusing to have those marked as included
update dbo.ProjectImage set IncludeInFactSheet = 1 where IsKeyPhoto = 1
update dbo.ProjectImageUpdate set IncludeInFactSheet = 1 where IsKeyPhoto = 1


update dbo.ProjectImage set IncludeInFactSheet = 0 where IncludeInFactSheet is null
update dbo.ProjectImageUpdate set IncludeInFactSheet = 0 where IncludeInFactSheet is null

alter table dbo.ProjectImage alter column IncludeInFactSheet bit not null
alter table dbo.ProjectImageUpdate alter column IncludeInFactSheet bit not null

alter table dbo.ProjectImage drop column ExcludeFromFactSheet
alter table dbo.ProjectImageUpdate drop column ExcludeFromFactSheet

update dbo.FieldDefinitionDefault set DefaultDefinition = '<p>Flags a photo so that it is included in the photos shown on the project&#39;s Fact Sheet. Some projects have tons of photos -- use this checkbox to control which photos are included.</p>' where FieldDefinitionID = 64
