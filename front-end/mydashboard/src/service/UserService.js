// here we will have functions that request from the .not web api
// for exmple
export async function checkUserExist (data) {
  const response = await fetch('back/api/users')
  return await response.json()
}
export async function createUser (data) {
  const response = await fetch('back/api/users', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  return await response.json()
}
